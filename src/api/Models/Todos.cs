namespace todos.api.Models;
public class Todos
{

    public string? Id{get;set;}
    public string? Title{get;set;}
    public string? Descrip{get;set;}
    public bool IsComplete{get;set;}
    public string? Category{get;set;}
    public int UserId{get;set;}

}
