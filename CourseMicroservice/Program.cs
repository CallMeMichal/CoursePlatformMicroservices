using CourseMicroservice.Events;
using CourseMicroservice.Mapper;
using CourseMicroservice.Repositories;
using CourseMicroservice.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<CourseRepository>();

// Add services to the container.
builder.Services.AddMassTransit(busConfigurator =>
{
    var entryAssembly = Assembly.GetExecutingAssembly();
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    // Explicitly add the consumer
    busConfigurator.AddConsumer<CourseEvent>();
    busConfigurator.AddConsumer<CreateLessonEvent>();
    busConfigurator.AddConsumer<DeleteCourseEvent>();
    busConfigurator.AddConsumer<DeleteLessonEvent>();
    busConfigurator.AddConsumer<GetAllCoursesEvent>();
    busConfigurator.AddConsumer<GetCourseEvent>();
    busConfigurator.AddConsumer<GetLessonEvent>();
    busConfigurator.AddConsumer<GetLessonsForCourseEvent>();
    busConfigurator.AddConsumer<UpdateCourseEvent>();
    busConfigurator.AddConsumer<UpdateLessonEvent>();
    

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
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();  // Tworzenie bazy danych, jeœli jeszcze nie istnieje
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
