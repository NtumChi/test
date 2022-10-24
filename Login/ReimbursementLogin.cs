namespace Login;

using UserServices;
using System.Text.Json;
using System.Collections.Generic;

public class ReimbursementLogin{
    
    public string user{get;set;}
    private string userName;
    private string userPassword;
    public string userId{get;set;}
    public decimal amount{get;set;}
    public string details{get;set;}
    public int ticketNumber{get;set;}
    public string comment{get;set;}
    EmployeeMenu emp = new EmployeeMenu();

    public ReimbursementLogin(){}

    public bool IdExists(string userId){
        if(emp.Exists(userId)){
            return true;
        }else{
            return false;
        }
    }
    public bool NameExists(string userName){
        if(emp.nameExists(userName)){
            return true;
        }else{
            return false;
        }
    }

    public string Create(string userName, string password){
        emp.Add(userName+password, userName, password);
        return userName;
    }

    public List<string> UsersOpen(){
        ManagerMenu users = new ManagerMenu();
        return users.UsersOpen();
    }
    public List<Object> UserForm(string user){
        ManagerMenu form = new ManagerMenu();
        return form.Form(user);
    }
    public void Approve(int ticketNumber){
        ManagerMenu ticket = new ManagerMenu();
        ticket.Approve(ticketNumber);
    }
    public void SendBack(int ticketNumber, string comment, string user){
        ManagerMenu ticket = new ManagerMenu();
        ticket.SendBack(ticketNumber,comment, user);
    }
    public List<Object> Form(decimal amount, string details, string userId){
        ReimbursementForm form = new ReimbursementForm();
        return form.AddForm(amount, details, userId);
    }

    public bool OldFormOpen(string userId){
        EmployeeMenu emp= new EmployeeMenu();
        if(emp.OldFormOpen(userId)==true){
            return true;
        }
        return false;
    }
    public List<Object> ReturnedForm(string userId){
        EmployeeMenu emp = new EmployeeMenu();
        return emp.GetOldForm(userId);
    }
    public void UpdateForm(string details, int ticketNumber){
        EmployeeMenu emp = new EmployeeMenu();
        emp.UpdateForm(details,ticketNumber);
    }
    public List<int> ClosedTickets(string userId){
        EmployeeMenu emp = new EmployeeMenu();
        return emp.GetClosedTickets(userId);
    }
    public List<Object> ClosedForm(int ticketNumber, string userId){
        EmployeeMenu emp = new EmployeeMenu();
        return emp.GetClosedForm(ticketNumber, userId);
    }


    //the standard login
    public void loginMenu(){

        Console.WriteLine("Hello, welcome to Revature-test Reimbursement Application.\n\nLogin\nUsername:\n\nIf you are a new user please type 'yes'.");

        String ans = Console.ReadLine();

        string user = "";

        if (ans.Equals("yes", StringComparison.OrdinalIgnoreCase)){
            newUserLogin();
        }else{
            this.userName = ans;
            Console.WriteLine("Login\nPassword:");
            this.userPassword = Console.ReadLine();
        }
        userId = userName + userPassword;
        string manager ="m+" + userName + userPassword;
        if (emp.Exists(manager)==true){
            user = "manager";
        }
        //if userId matches manager then use ManagerMenu
        if (user == "manager"){
            ManagerMenu menu = new ManagerMenu(manager);
        }else{
            EmployeeMenu menu2 = new EmployeeMenu(userId, userName);
        }

    }

    //a login for new users
    public void newUserLogin(){
        Console.WriteLine("If you are a manager please enter 'yes' again, otherwise enter your new Username:");
        String ans = Console.ReadLine();
        if(ans.Equals("yes", StringComparison.OrdinalIgnoreCase)){
            newManagerLogin();
        }else{
            this.userName = ans;
            while(emp.nameExists(userName)==true){
                Console.WriteLine("Your username exists, please enter another.");
                userName = Console.ReadLine();
            }
            Console.WriteLine("Please enter your Password:");
            this.userPassword = Console.ReadLine();
            //add database call for users
            userId = userName + userPassword;
            //checks if userId exists already
            while(emp.Exists(userId)==true){
                //write message telling them to enter user/pass again
                Console.WriteLine("");
            }
            emp.Add(userId, userName, userPassword);

        }
    }
    
    //a login for managers
    public void newManagerLogin(){
        Console.WriteLine("Please enter your desired Username:");
        this.userName = Console.ReadLine();
        while(emp.nameExists(userName)==true){
            Console.WriteLine("Your username exists, please enter another.");
            userName = Console.ReadLine();
        }
        Console.WriteLine("Please enter your Password:");
        this.userPassword = Console.ReadLine();

        userId = "m+" + userName + userPassword;
        while(emp.Exists(userId)==true){
            //write message telling them to enter user/pass again
            Console.WriteLine("");
        }
        emp.Add(userId, userName, userPassword);
    }

}
