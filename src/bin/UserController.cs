// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Data.SqlClient;
// namespace todos.api.Controllers;

// [ApiController]
// [Route("[controller]")]

// public class UserController : ControllerBase

// {
//     public readonly IConfiguration _configuration;
//         // Response response;
//         public UserController(IConfiguration configuration) //constructor
//         {
//             _configuration = configuration;
//         }
//     [HttpGet]
//     public IActionResult Get()
//     {
//         var connectionString = _configuration.GetConnectionString("connectionStr").ToString();

//         using (SqlConnection connection = new SqlConnection(connectionString))
//         {
//             connection.Open();

//             using (SqlCommand command = new SqlCommand("select * from Test.AJUser", connection))
//             {
//                 using (SqlDataReader dataReader = command.ExecuteReader())
//                 {
//                     var results = new List<object>();

//                     while (dataReader.Read())
//                     {
//                         var result = new
//                         {
//                             UserId = dataReader.GetInt32(0),
//                             UserName = dataReader.GetString(1),
//                             Email = dataReader.GetString(2),
//                             Password = dataReader.GetString(3)
//                         };

//                         results.Add(result);
//                     }

//                     return Ok(results);
//                 }
//             }
//         }
//     }
//     [HttpGet("{id}")]
//     public IActionResult Get(int id)
//     {
//         var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
//         using (SqlConnection connection = new SqlConnection(connectionString))
//         {
//             connection.Open();
//             SqlCommand command = new SqlCommand($"select * from Test.AJUser WHERE UserId = {id}", connection);
//             SqlDataReader dataReader = command.ExecuteReader();

//             if (dataReader.HasRows)
//             {
//                 dataReader.Read();
//                 return Ok(new
//                 {
//                     UserId = dataReader.GetInt32(0),
//                         UserName = dataReader.GetString(1),
//                         Email = dataReader.GetString(2),
//                         Password = dataReader.GetString(3)
//                 });
//             }
//             else
//             {
//                 return NotFound();
//             }
//         }
//     }
//     [HttpPost]
//     public IActionResult Post(Models.Users user)
//     {
//         var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
//         using (SqlConnection connection = new SqlConnection(connectionString))
//         {
//             connection.Open();
//             SqlCommand command = new SqlCommand($"INSERT INTO Test.AJUser(UserId, UserName, Email, Password) VALUES ('{user.UserId}', '{user.UserName}','{user.Email}', '{user.Password}')", connection);
//             int rowsAffected = command.ExecuteNonQuery();

//             if (rowsAffected > 0)
//             {
//                 return Ok();
//             }
//             else
//             {
//                 return BadRequest();
//             }
//         }

//     }
//     [HttpDelete]
//     public IActionResult Delete(int id)
//     {
//         var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
//         using (SqlConnection connection = new SqlConnection(connectionString))
//         {
//             connection.Open();
//             SqlCommand command = new SqlCommand($"Delete from Test.AJUser Where UserId={id}", connection);
//             int rowsAffected = command.ExecuteNonQuery();

//             if (rowsAffected > 0)
//             {
//                 return Ok();
//             }
//             else
//             {
//                 return BadRequest();
//             }
//         }
        
//     }

//     [HttpPut]
//     public IActionResult Put(int id, Models.Users user)
//     {
//         var connectionString = _configuration.GetConnectionString("connectionStr").ToString();
//          using (SqlConnection connection = new SqlConnection(connectionString))
//         {
//             connection.Open();
//             SqlCommand command = new SqlCommand($"Update Test.AJUser Set UserId ='{user.UserId}', UserName ='{user.UserName}',Email='{user.Email}', Password='{user.Password}' Where UserId={id}", connection);
//             int rowsAffected = command.ExecuteNonQuery();

//             if (rowsAffected > 0)
//             {
//                 return Ok();
//             }
//             else
//             {
//                 return BadRequest();
//             }
//         }
//     }
// }

