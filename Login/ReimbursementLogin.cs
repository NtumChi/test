using UserServices;

class ReimbursementLogin{
    
    private string userName;
    private string userPassword;
    private string userId;
    Employee emp = new Employee();

    //runs the initial application
    public void run(){
        loginMenu();
    }

    //the standard login
    public void loginMenu(){

        Console.WriteLine("Hello, welcome to Revature-test Reimbursement Application.\n\nLogin\nUsername:\n\nIf you are a new user please type 'yes'.");

        String ans = Console.ReadLine();

        if (ans.Equals("yes", StringComparison.OrdinalIgnoreCase)){
            newUserLogin();
            //create new userId and save
        }else{
            this.userName = ans;
            Console.WriteLine("Login\nPassword:");
            this.userPassword = Console.ReadLine();
            userId = userName + userPassword;
            string user = "";
            if (emp.ManagerExists(userId)==true){
                user = "manager";
            }

        }
        //if userId matches manager then use ManagerMenu
        if (userId == "manager"){
            ManagerMenu menu = new ManagerMenu(userId);
        }else{
            ReimbursementForm form = new ReimbursementForm(userId);
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
            Console.WriteLine("Please enter your Password:");
            this.userPassword = Console.ReadLine();
            //add database call for users
            userId = userName + userPassword;
            //checks if userId exists already
            while(emp.EmployeeExists(userId)==true){
                //write message telling them to enter user/pass again
                Console.WriteLine("");
            }

        }
    }
    
    //a login for managers
    public void newManagerLogin(){
        Console.WriteLine("Please enter your desired Username:");
        this.userName = Console.ReadLine();
        Console.WriteLine("Please enter your Password:");
        this.userPassword = Console.ReadLine();

        userId = "M+"+ userName + userPassword;
        while(emp.ManagerExists(userId)==true){
            //write message telling them to enter user/pass again
            Console.WriteLine("");
        }
    }

}
