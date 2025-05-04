using LoginRegisterMicroservice.Repositories.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using SharedModels.Models.LoginRegisterModels.Request;
using SharedModels.Models.LoginRegisterModels.Response;

namespace LoginRegisterMicroservice.Repositories
{
    public class LoginRepository
    {
        private readonly AppDbContext _context;

        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
