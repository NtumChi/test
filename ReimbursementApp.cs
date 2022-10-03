class ReimbursementApp{
    
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
        }else{
            this.userName = Console.ReadLine();
            //more
        }

    }

    //a login for new users
    public void newUserLogin(){
        Console.WriteLine("");
    }
}
