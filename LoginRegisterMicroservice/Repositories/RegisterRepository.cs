using LoginRegisterMicroservice.Repositories.DatabaseModels;

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
