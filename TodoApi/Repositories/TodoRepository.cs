using TodoApi.Models;
namespace TodoApi.Repositories;
using TodoApi.Data;
using Microsoft.EntityFrameworkCore;

public class TodoRepository : ITodoRepository
{
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

    private readonly ApplicationDbContext _context;
    public TodoRepository(ApplicationDbContext context)
    {
        _context=context;
    }
    // public List<Todo> GetAll()
    // {
    //     return _context.Todos.ToList();
    // }
    public async Task<List<Todo>> GetAll()
    {
        return await _context.Todos.ToListAsync();
        throw new Exception("Database Exploded");
    }
    // public Todo? GetById(int id)
    // {
    //     return _context.Todos.FirstOrDefault(t => t.Id == id);
    // }
    public async Task<Todo?> GetById(int id)
    {
        return await _context.Todos.FirstOrDefaultAsync(t=>t.Id==id);
    } 
    // public Todo Create(Todo todo)
    // {
    //     todo.CreatedDate=DateTime.Now;
    //     _context.Todos.Add(todo);
    //     _context.SaveChanges();
    //     return todo;
    // }
    public async Task<Todo> Create(Todo todo)
    {
        todo.CreatedDate=DateTime.Now;
        await _context.AddAsync(todo);
        await _context.SaveChangesAsync();
        return todo;
    }
    // public Todo? Update(int id,Todo updatedtodo)
    // {
    //     var existingTodo= GetById(id);
    //     if (existingTodo == null)
    //     {
    //         return null;
    //     }
    //     existingTodo.Title=updatedtodo.Title;
    //     existingTodo.Description=updatedtodo.Description;
    //     existingTodo.IsCompleted=updatedtodo.IsCompleted;
    //     _context.SaveChanges();
    //     return existingTodo;
    // }
    public async Task<Todo?> Update(int id,Todo updatedtodo)
    {
        var existingTodo = await GetById(id);
        if (existingTodo == null)
        {
            return null;
        }
        existingTodo.Title=updatedtodo.Title;
        existingTodo.Description=updatedtodo.Description;
        existingTodo.IsCompleted=updatedtodo.IsCompleted;
        await _context.SaveChangesAsync();
        return existingTodo;
    }
    // public bool Delete(int id)
    // {
    //     var todo=GetById(id);
    //     if (todo == null)
    //     {
    //         return false;
    //     }
    //     _context.Todos.Remove(todo);
    //     _context.SaveChanges();
    //     return true;
    // }
    public async Task<bool> Delete(int id)
    {
        var todo = await GetById(id);
        if(todo == null)
        {
            return false;
        }
        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
        return true;
    }
}