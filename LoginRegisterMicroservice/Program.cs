using LoginRegisterMicroservice.Events;
using LoginRegisterMicroservice.Services;
using LoginRegisterMicroservice.Repositories;
using MassTransit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var rabbitMQConfig = builder.Configuration.GetSection("RabbitMQConfig").Get<RabbitMQConfig>();

// Register your repositories
builder.Services.AddScoped<LoginRepository>();
builder.Services.AddScoped<RegisterRepository>();

// Register your services here
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<RegisterService>();

builder.Services.AddMassTransit(busConfigurator =>
{
    var entryAssembly = Assembly.GetExecutingAssembly();
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    // Explicitly add the consumer
    busConfigurator.AddConsumer<LoginUserEvent>();
    busConfigurator.AddConsumer<RegisterUserEvent>();

    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        configurator.PrefetchCount = 1;
        configurator.ConfigureEndpoints(context);
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();  // Tworzenie bazy danych, je�li jeszcze nie istnieje
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
    policy.WithOrigins("http://localhost:3000")
          .AllowAnyHeader()
          .AllowAnyMethod());

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();