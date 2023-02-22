using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using todos.api.Models;
namespace todos.api.Repository;
public class UserRepository : ControllerBase
{
    public UserRepository()
    {

    }

    public IActionResult GetAllUser(SqlConnection connection)
    {
        connection.Open();

        using (SqlCommand command = new SqlCommand("select * from Test.AJUser", connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                var results = new List<object>();

                while (reader.Read())
                {
                    var result = new
                    {
                        UserId = reader.GetString(0),
                        UserName = reader.GetString(1),
                        Email = reader.GetString(2),
                        Password = reader.GetString(3)
                    };

                    results.Add(result);
                }

                return Ok(results);
            }
        }
    }

    public IActionResult GetByUserId(SqlConnection connection, string id)
    {
        connection.Open();
        SqlCommand command = new SqlCommand($"select * from Test.AJUser WHERE UserId = {id}", connection);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            reader.Read();
            return Ok(new
            {
               UserId = reader.GetString(0),
                UserName = reader.GetString(1),
                Email = reader.GetString(2),
                Password = reader.GetString(3)
            });
        }
        else
        {
            return NotFound();
        }

    }

    public IActionResult AddUser(Users user, SqlConnection connection)
    {

        connection.Open();
        SqlCommand command = new SqlCommand($"INSERT INTO Test.AJUser(UserId, UserName, Email, Password) VALUES ('{user.UserId}', '{user.UserName}','{user.Email}', '{user.Password}')", connection);
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

    public IActionResult DeleteUser(string id, SqlConnection connection)
    {

        connection.Open();
        SqlCommand command = new SqlCommand($"Delete from Test.AJUser Where UserId={id}", connection);
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

    public IActionResult UpdateUser(string id, Users user, SqlConnection connection)
    {
        connection.Open();
        SqlCommand command = new SqlCommand($"Update Test.AJUser Set UserId ='{user.UserId}', UserName ='{user.UserName}',Email='{user.Email}', Password='{user.Password}' Where UserId={id}", connection);
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