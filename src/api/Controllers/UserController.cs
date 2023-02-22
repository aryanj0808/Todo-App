using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using todos.api.Repository;
using todos.api.Models;
namespace todos.api.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase

{
    public readonly IConfiguration _configuration;
        // Response response;
        public UserController(IConfiguration configuration) //constructor
        {
            _configuration = configuration;
        }
    [HttpGet]
    public IActionResult Get()
    {
        var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        UserRepository response=new UserRepository();
        var result=response.GetAllUser(connection);
        return result;

        
    }
    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        UserRepository response=new UserRepository();
        var result=response.GetByUserId(connection,id);
        return result;
    }
    [HttpPost]
    public IActionResult Post(Users user)
    {
        var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        UserRepository response=new UserRepository();
        var result=response.AddUser(user,connection);
        return result;

    }
    [HttpDelete]
    public IActionResult Delete(string id)
    {
        var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        UserRepository response=new UserRepository();
        var result=response.DeleteUser(id,connection);
        return result;
        
    }

    [HttpPut]
    public IActionResult Put(string id,Users user)
    {
        var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        UserRepository response=new UserRepository();
        var result=response.UpdateUser(id,user,connection);
        return result;
    }
}

