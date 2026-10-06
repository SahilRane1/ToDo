using TodoApi.Models;
namespace TodoApi.Repositories;

public interface ITodoRepository
{
    Task<List<Todo>> GetAll();
    Task<Todo?> GetById(int id);
    Task<Todo> Create(Todo todo);
    Task<Todo?> Update(int id,Todo todo);
    Task<bool> Delete(int id);
}