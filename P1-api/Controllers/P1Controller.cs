using Microsoft.AspNetCore.Mvc;
using Login;

namespace P1_api.Controllers;

[ApiController]
[Route("[controller]")]
public class P1Controller : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<P1Controller> _logger;

    public P1Controller(ILogger<P1Controller> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetP1")]
    public IEnumerable<P1> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new P1
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    [HttpPost]
    public ActionResult<string> Login(string userName, string password){
        ReimbursementLogin login = new ReimbursementLogin();
        userName = login.Deserialize(userName);
        password = login.Deserialize(password);
        if (login.Exists(userName) == true){
            return Unauthorized(new {mssge = "Username is taken. Please enter a new Username."});
        }else{
            login.Create(userName, password);
            return Created("Created New User Account.", login.Serialize(userName));
        }
    }
  
}
