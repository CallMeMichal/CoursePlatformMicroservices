using LoginRegisterMicroservice.Repositories.DatabaseModels;
using LoginRegisterMicroservice.Services;
using MassTransit.NewIdProviders;
using Microsoft.EntityFrameworkCore;
using SharedModels.Models.LoginRegisterModels.Request;
using SharedModels.Models.LoginRegisterModels.Response;

namespace LoginRegisterMicroservice.Repositories
{
    public class RegisterRepository
    {
        private readonly AppDbContext _context;
        public RegisterRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

    }
}
