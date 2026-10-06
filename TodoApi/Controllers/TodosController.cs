using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;
using TodoApi.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class TodosController : ControllerBase
{
    private readonly ITodoService _todoService;
    public TodosController(ITodoService todoService)
    {
        _todoService=todoService;
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
    //     },
    //     new Todo
    //     {
    //         Id = 2,
    //         Title = "Learn Angular",
    //         Description = "Study Components",
    //         IsCompleted = true,
    //         CreatedDate = DateTime.Now
    //     }
    // };
    // [HttpGet]
    // public IActionResult GetTodos()
    // {
    //     return Ok(_todos);
    // }
    // [HttpGet]
    // public IActionResult GetTodos()
    // {
    //     return Ok(_todoService.GetAll());
    // }
    // Async : Without DTO : 
    // [HttpGet]
    // public async Task<IActionResult> GetTodos()
    // {
    //     var todos= await _todoService.GetAll();
    //     return Ok(todos);
    // }
    // With DTO

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        var todos= await _todoService.GetAll();
        var response = todos.Select(t=>new TodoResponseDto
        {
            Id=t.Id,
            Title=t.Title,
            Description=t.Description,
            IsCompleted=t.IsCompleted
        });

        return Ok(response);
    }

    // [HttpGet("{id:int}")]
    // public IActionResult GetTodoByID(int id)
    // {
    //     var todo=_todos.FirstOrDefault(t=>t.Id==id);
    //     if (todo == null)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(todo);
    // }

    // [HttpGet("{id:int}")]
    // public IActionResult GetTodoByID(int id)
    // {
    //     var todo= _todoService.GetById(id);
    //     if (todo == null)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(todo);
    // }
    // Async: Withoud DTO : 
    // [HttpGet("{id:int}")]
    // public async Task<IActionResult> GetTodoByID(int id)
    // {
    //     var todo= await _todoService.GetById(id);
    //     if (todo == null)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(todo);
    // }

    // With DTO : 
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTodoByID(int id)
    {
        var todo= await _todoService.GetById(id);
        if (todo == null)
        {
            return NotFound();
        }
        var response = new TodoResponseDto
        {
            Id=todo.Id,
            Title=todo.Title,
            Description=todo.Description,
            IsCompleted=todo.IsCompleted
        };
        return Ok(response);
    }

    // [HttpPost]
    // public IActionResult CreateTodo(Todo todo)
    // {
    //     todo.Id=_todos.Max(t=>t.Id)+1;
    //     todo.CreatedDate=DateTime.Now;
    //     _todos.Add(todo);

    //     // return Ok(todo);
    //     return CreatedAtAction(
    //         nameof(GetTodoByID),
    //         new{id=todo.Id},
    //         todo
    //     );
    // }

    // [HttpPost]
    // public IActionResult CreateTodo(Todo todo)
    // {
    //     var createdTodo=_todoService.Create(todo);

    //     // return Ok(createdTodo);
    //     return CreatedAtAction(
    //         nameof(GetTodoByID),
    //         new{id=createdTodo.Id},
    //         createdTodo
    //     );
    // }

    // Async: Without DTOs
    // [HttpPost]
    // public async Task<IActionResult> CreateTodo(Todo todo)
    // {
    //     var createdTodo= await _todoService.Create(todo);

    //     // return Ok(createdTodo);
    //     return CreatedAtAction(
    //         nameof(GetTodoByID),
    //         new{id=createdTodo.Id},
    //         createdTodo
    //     );
    // }
    // With DTOs
    [HttpPost]
    public async Task<IActionResult> CreateTodo(CreateTodoRequestDto dto)
    {
        var todo = new Todo
        {
            Title=dto.Title,
            Description=dto.Description
        };
        var createdTodo = await _todoService.Create(todo);

        var response = new TodoResponseDto
        {
            Id=createdTodo.Id,
            Title=createdTodo.Title,
            Description=createdTodo.Description,
            IsCompleted=createdTodo.IsCompleted
        };
        return CreatedAtAction(nameof(GetTodoByID),new{id=response.Id},response);
    }

    

    // [HttpPut("{id:int}")]
    // public IActionResult UpdateTodo(int id, Todo updatedTodo)
    // {
    //     if (id != updatedTodo.Id)
    //     {
    //         return BadRequest("Route ID and Todo ID must match.");
    //     }
    //     var existingTodo=_todos.FirstOrDefault(t=>t.Id==id);
    //     if(existingTodo == null)
    //     {
    //         return NotFound();
    //     }
    //     existingTodo.Title=updatedTodo.Title;
    //     existingTodo.Description=updatedTodo.Description;
    //     existingTodo.IsCompleted=updatedTodo.IsCompleted;

    //     return Ok(existingTodo);
    // }
    // [HttpPut("{id:int}")]
    // public IActionResult UpdateTodo(int id, Todo updatedTodo)
    // {
    //     if (id != updatedTodo.Id)
    //     {
    //         return BadRequest();
    //     }
    //     var updated=_todoService.Update(id,updatedTodo);
    //     if (updated == null)
    //     {
    //         return NotFound();
    //     }
        
        
    //     return Ok(updated);
    // }

    // Async:
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTodo(int id, Todo updatedTodo)
    {
        if (id != updatedTodo.Id)
        {
            return BadRequest();
        }
        var updated=await _todoService.Update(id,updatedTodo);
        if (updated == null)
        {
            return NotFound();
        }
        
        
        return Ok(updated);
    }


    // [HttpDelete("{id:int}")]
    // public IActionResult DeleteTodo(int id)
    // {
    //     var todo=_todos.FirstOrDefault(t=>t.Id==id);
    //     if (todo == null)
    //     {
    //         return NotFound();
    //     }
    //     _todos.Remove(todo);

    //     return NoContent();
    // }

    // [HttpDelete("{id:int}")]
    // public IActionResult DeleteTodo(int id)
    // {
    //     var deleted=_todoService.Delete(id);
    //     if (deleted==false)
    //     {
    //         return NotFound();
    //     }
    //     return NoContent();
    // }

    // Async:
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        var deleted=await _todoService.Delete(id);
        if (deleted==false)
        {
            return NotFound();
        }
        return NoContent();
    }

    // [HttpGet("completed")]
    // public IActionResult GetCompletedTodo()
    // {
    //     var completedTodos = new List<Todo>
    // {
    //     new Todo
    //     {
    //         Id = 2,
    //         Title = "Learn Angular",
    //         Description = "Study Components",
    //         IsCompleted = true,
    //         CreatedDate = DateTime.Now
    //     }
    // };
    //     return Ok(completedTodos);
    // }

    // [HttpGet("hello")]
    // public IActionResult SayHello()
    // {
    //     return Ok("Hello Sahil");
    // }
    
    // [HttpGet("count")]
    // public IActionResult GetCount()
    // {
    //     return Ok(3);
    // }
    
    // [HttpGet("1")]
    // public IActionResult Count()
    // {
    //     return Ok("Todo ID: 1");
    // }

    // [HttpGet("{greet:alpha}")]
    // public IActionResult Todos(string greet)
    // {
    //     return Ok(greet+" Sahil");
    // }

    // [HttpGet("{id:int}")]
    // public IActionResult Todos(int id)
    // {
    //     return Ok(id);
    // }


}

