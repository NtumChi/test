class ReimbursementLogin{
    
    private string userName;
    private string userPassword;

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
            string userId = "test";
            ReimbursementForm form = new ReimbursementForm(userId);
        }else{
            this.userName = Console.ReadLine();
            Console.WriteLine("Login\nPassword:");
            this.userPassword = Console.ReadLine();
            //pull username/password info to get userId
            string userId = "test";
            ReimbursementForm form = new ReimbursementForm(userId);
        }

    }

    //a login for new users
    public void newUserLogin(){
        Console.WriteLine("If you are a manager please enter 'yes' again, otherwise enter your new Username:");
        String ans = Console.ReadLine();
        if(ans.Equals("yes", StringComparison.OrdinalIgnoreCase)){
            managerLogin();
        }else{
            this.userName = ans;
            Console.WriteLine("Please enter your Password:");
            this.userPassword = Console.ReadLine();
            //add database call for users
        }
    }
    
    //a login for managers
    public void managerLogin(){
        Console.WriteLine("Please enter your desired Username:");
        this.userName = Console.ReadLine();
        Console.WriteLine("Please enter your Password:");
        this.userPassword = Console.ReadLine();
        //database call for managers
    }

}
