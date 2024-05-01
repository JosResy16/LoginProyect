using Microsoft.EntityFrameworkCore;
using LoginProyect.Models;
using LoginProyect.Services.Interfaces;

namespace LoginProyect.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly LoginTestDbContext _context;

        public UserService(LoginTestDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(string email, string password)
        {
            User user_found = await _context.Users.Where(u=> u.Email == email && u.Password == password)
                .FirstOrDefaultAsync();

            return user_found;
        }

        public async Task<User> SaveUser(User model)
        {
            _context.Users.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
