using Microsoft.AspNetCore.Mvc;
using Login;

namespace P1_api.Controllers;

public class User{
public string userName{get;set;}
public string password{get; set;}
}

[ApiController]
[Route("[controller]")]
public class P1Controller : ControllerBase
{
    string userId;
    string userName;

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<P1Controller> _logger;

    public P1Controller(ILogger<P1Controller> logger)
    {
        _logger = logger;
    }

    // [HttpGet(Name = "GetP1")]
    // public IEnumerable<P1> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new P1
    //     {
    //         Date = DateTime.Now.AddDays(index),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }
    [HttpPost]
    [Route("Register/")]
    public ActionResult Register(User user){
        ReimbursementLogin register = new ReimbursementLogin();
        string userName = user.userName;
        string password = user.password;
        userId = userName+password;

        if (register.Exists(userName) == true){
            return Unauthorized("User already exists");
        }else{
            return Created("User Created", register.Create(userName, password));
        }
    }

    [HttpPost]
    [Route("Login/")]
    public ActionResult Login(User user){
        ReimbursementLogin login = new ReimbursementLogin();
        string userName = user.userName;
        string password = user.password;
        string userId = userName+password;

        
        if (login.Exists(userName) == true){
            return Ok("user");
        }else{
            
            return Unauthorized("User not in database.");
        }
    }

    // [HttpPost]
    // public ActionResult<string> CreateForm(decimal amount, string details){
    //     ReimbursementLogin login = new ReimbursementLogin();
    //     amount = decimal.Parse(login.Deserialize(amount.ToString()));
    //     details = login.Deserialize(details);
    //     return Created("Your form has been created", login.Form(amount, details, userId));
    // }

    // [HttpGet]
    // public IEnumerable<Object> ReturnedForm(){
    //     ReimbursementLogin login = new ReimbursementLogin();
    //     return login.ReturnedForm(userId);
    // }

    // [HttpGet]
    // public IEnumerable<int> ClosedTickets(){
    //     ReimbursementLogin login = new ReimbursementLogin();
    //     return login.ClosedTickets(userId);
    // }

    // [HttpGet]
    // public IEnumerable<Object> ClosedForm(int ticketNumber){
    //     ReimbursementLogin login = new ReimbursementLogin();
    //     ticketNumber = int.Parse(login.Deserialize(ticketNumber.ToString()));
    //     return login.ClosedForm(ticketNumber, userId);
    // }
  
}
