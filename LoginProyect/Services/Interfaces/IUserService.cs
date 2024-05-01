using Microsoft.EntityFrameworkCore;
using LoginProyect.Models;

namespace LoginProyect.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(string email, string password);
        Task<User> SaveUser(User model);
    }
}
