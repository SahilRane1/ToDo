using System.Net.Http.Headers;
using TodoApi.Models;
using TodoApi.Repositories;
namespace TodoApi.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository=todoRepository;
    }
    // private static List<Todo> _todos = new()
    // {
    //     new Todo
    //     {
    //         Id = 1,
    //         Title = "Learn ASP.NET Core",
    //         Description = "Study APIs",
    //         IsCompleted = false,
    //         CreatedDate = DateTime.Now
    //     }
    // };

    // public List<Todo> GetAll()
    // {
    //     return _todos;
    // }  
    // public List<Todo> GetAll()
    // {
    //     return _todoRepository.GetAll();
    // }  
    public Task<List<Todo>> GetAll()
    {
        return _todoRepository.GetAll();
    }
    // public Todo? GetById(int id)
    // {
    //     return _todos.FirstOrDefault(t=>t.Id==id);
    // }
    // public Todo? GetById(int id)
    // {
    //     return _todoRepository.GetById(id);
    // }
    public Task<Todo?> GetById(int id)
    {
        return _todoRepository.GetById(id);
    }
    // public Todo Create(Todo todo)
    // {
    //     todo.Id=_todos.Max(t=>t.Id)+1;
    //     todo.CreatedDate=DateTime.Now;
    //     _todos.Add(todo);
    //     return todo;
    // }
    // public Todo Create(Todo todo)
    // {
    //     return _todoRepository.Create(todo);
    // }
    public Task<Todo> Create(Todo todo)
    {
        return _todoRepository.Create(todo);
    }
    // public Todo? Update(int id,Todo updatedtodo)
    // {
    //     var existingTodo=GetById(id);
    //     if (existingTodo == null)
    //     {
    //         return null;
    //     }
    //     existingTodo.Title=updatedtodo.Title;
    //     existingTodo.Description=updatedtodo.Description;
    //     existingTodo.IsCompleted=updatedtodo.IsCompleted;
    //     return existingTodo;
    // }
    // public Todo? Update(int id,Todo updatedtodo)
    // {
    //     return _todoRepository.Update(id,updatedtodo);
    // }
    public Task<Todo?> Update(int id,Todo updatedtodo)
    {
        return _todoRepository.Update(id,updatedtodo);
    }
    // public bool Delete(int id)
    // {
    //     var todo=GetById(id);
    //     if (todo == null)
    //     {
    //         return false;
    //     }
    //     _todos.Remove(todo);
    //     return true;
    // }
    // public bool Delete(int id)
    // {
    //     return _todoRepository.Delete(id);
    // }
    public Task<bool> Delete(int id)
    {
        return _todoRepository.Delete(id);
    }
    
}