using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using todos.api.Repository;
using todos.api.Models;
namespace todos.api.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase
{
    public readonly IConfiguration _configuration;
 
    public TodosController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        TodosRepository response = new TodosRepository();
        var result = response.GetAll(connection);
        return result;

    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        TodosRepository response = new TodosRepository();
        var result = response.GetById(connection, id);
        return result;

    }

    [HttpPost]
    public IActionResult Post(Todos todos)
    {
        var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        TodosRepository response = new TodosRepository();
        var result = response.AddTodos(todos, connection);
        return result;

    }

    [HttpDelete]
    public IActionResult Delete(string id)
    {
        var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        TodosRepository response = new TodosRepository();
        var result = response.DeleteTodo(id, connection);
        return result;
    }

    [HttpPut]
    public IActionResult Put(string id, Todos todos)
    {
        var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        TodosRepository response = new TodosRepository();
        var result = response.UpdateTodo(id, todos, connection);
        return result;
    }
}