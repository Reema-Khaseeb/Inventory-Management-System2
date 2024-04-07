using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Db.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Db.Repositories;
public class UserRepository : IUserRepository
{
    private readonly InventoryManagementSystemDbContext _dbContext;

    public UserRepository(InventoryManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<User> CreateUserAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<User> GetUserByIdAsync(int userId)
    {
        return await _dbContext.Users.FindAsync(userId);
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        return await _dbContext.Users
                .SingleOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _dbContext.Users
                .SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<bool> IsUsernameUniqueAsync(string username)
    {
        return !await _dbContext.Users.AnyAsync(u => u.Username == username);
    }

    public async Task<bool> IsEmailUniqueAsync(string email)
    {
        return !await _dbContext.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<bool> IsUserExistAsync(int userId) =>
        await _dbContext.Users.AnyAsync(u => u.UserId == userId);
}
