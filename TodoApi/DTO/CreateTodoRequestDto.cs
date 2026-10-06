namespace TodoApi.DTOs;
using System.ComponentModel.DataAnnotations;

public class CreateTodoRequestDto
{
    [Required(ErrorMessage ="Title is Mandatory")]
    [StringLength(100,ErrorMessage ="Title cannot exceed 100 characters")]
    public string Title{get;set;}=string.Empty;
    [Required(ErrorMessage ="Description is Mandatory")]
    [StringLength(500,ErrorMessage ="Description cannot exceed 500 characters")]
    public string Description{get;set;}=string.Empty;
}