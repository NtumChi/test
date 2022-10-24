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

        if (register.NameExists(userName) == true){
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
        userId = userName+password;

        
        if (login.NameExists(userName) == true){
            return Ok(userName);
        }else{
            
            return Unauthorized("User not in database.");
        }
    }

    [HttpPost]
    [Route("CreateForm/")]
    public ActionResult<string> CreateForm(ReimbursementLogin form){
        return Created("Your form has been created", form.Form(form.amount, form.details, form.userId));
    }

    [HttpGet]
    [Route("ReturnedForm/")]
    public IEnumerable<Object> ReturnedForm(ReimbursementLogin form){
        return form.ReturnedForm(form.userId);
    }

    [HttpPost]
    [Route("UpdateForm/")]
    public ActionResult UpdateForm(ReimbursementLogin form){
        form.UpdateForm(form.details, form.ticketNumber);
        return Ok("Form updated.");
    }

    [HttpGet]
    [Route("ClosedTickets/")]
    public IEnumerable<int> ClosedTickets(ReimbursementLogin tickets){
        return tickets.ClosedTickets(tickets.userId);
    }

    [HttpGet]
    [Route("ClosedForm/")]
    public IEnumerable<Object> ClosedForm(ReimbursementLogin form){
        return form.ClosedForm(form.ticketNumber, form.userId);
    }
    [HttpGet]
    [Route("UsersOpen/")]
    public IEnumerable<string>? UsersOpen(ReimbursementLogin manager){
        if(manager.userId.Contains("m+")){
            if(manager.IdExists(manager.userId)){
                return manager.UsersOpen();
            }
        }
        return null;
    }
    [HttpGet]
    [Route("OpenForm/")]
    public IEnumerable<Object>? OpenForm(ReimbursementLogin manager){
        if(manager.userId.Contains("m+")){
            if(manager.IdExists(manager.userId)){
                return manager.UserForm(manager.user);
            }
        }
        return null;
    }
    [HttpPost]
    [Route("Approve/")]
    public ActionResult Approve(ReimbursementLogin ticketNumber){
        if(ticketNumber.userId.Contains("m+")){
            if(ticketNumber.IdExists(ticketNumber.userId)){
                ticketNumber.Approve(ticketNumber.ticketNumber);
                return  Ok("The form has been approved.");
            }
        }
        return Unauthorized();
    }
    [HttpPost]
    [Route("SendBack/")]
    public ActionResult SendBack(ReimbursementLogin ticketNumber){
        if(ticketNumber.userId.Contains("m+")){
            if(ticketNumber.IdExists(ticketNumber.userId)){
                ticketNumber.SendBack(ticketNumber.ticketNumber, ticketNumber.comment, ticketNumber.user);
                return Ok("sent back.");
            }
        }
        return Unauthorized();
    }
  
}
