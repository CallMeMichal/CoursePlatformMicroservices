using LoginRegisterMicroservice.Repositories.DatabaseModels;
using Microsoft.EntityFrameworkCore;

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
