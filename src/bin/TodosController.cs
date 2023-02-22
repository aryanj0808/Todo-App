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
        // Response response;
        public TodosController(IConfiguration configuration) //constructor
        {
            _configuration = configuration;
        }
    [HttpGet]
    public List<Todos> Get()
    {
        var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("select * from Test.AJTodosapp", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var results = new List<object>();

                    while (reader.Read())
                    {
                        var result = new
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            Category = reader.GetString(3),
                            IsCompleted = reader.GetBoolean(4),
                            UserId = reader.GetInt32(5)
                        };

                        results.Add(result);
                    }

                    return Ok(results);
                }
            }
        }
        
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand($"select * from Test.AJTodosapp WHERE Id = {id}", connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                return Ok(new
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Description = reader.GetString(2),
                    Category = reader.GetString(3),
                    IsCompleted = reader.GetBoolean(4),
                    UserId = reader.GetInt32(5)
                });
            }
            else
            {
                return NotFound();
            }
        }
    }
    [HttpPost]
    public IActionResult Post(Models.Todos todos)
    {
        var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand($"INSERT INTO Test.AJTodosapp (Id, Title, Descrip, IsComplete, Category, UserId) VALUES ('{todos.Id}', '{todos.Title}','{todos.Descrip}', '{todos.IsComplete}','{todos.Category}', '{todos.UserId}')", connection);
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand($"Delete from Test.AJTodosapp Where id={id}", connection);
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        
    }

    [HttpPut]
    public IActionResult Put(int id, Models.Todos todos)
    {
        var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
         using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand($"Update Test.AJTodosapp Set Title ='{todos.Title}', Descrip ='{todos.Descrip}',Category='{todos.Category}', IsComplete='{todos.IsComplete}', UserId='{todos.UserId}' Where id={id}", connection);
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}