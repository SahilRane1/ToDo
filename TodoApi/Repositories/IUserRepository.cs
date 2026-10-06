using TodoApi.Models;
namespace TodoApi.Repositories;

public interface IUserRepository
{
    Task<User?> GetByUserName(string UserName); 
}