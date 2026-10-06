using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context=context;
    }
    public async Task<User?> GetByUserName(string UserName)
    {
        return await _context.Users.FirstOrDefaultAsync(u=>u.UserName==UserName);
    }
}