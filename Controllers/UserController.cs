using Microsoft.AspNetCore.Mvc;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    [HttpGet("{id}")]
    [Produces("application/json")]
    public ActionResult<User> GetUser(int id)
    {
        var user = new User
        {
            Id = id,
            Name = $"John Doe",
            Email = "john@gmail.com"
        };
        return Ok(user);
    }
}