class ReimbursementForm{

    //possibly come up with class for ticketNumbers
    private int ticketNumber{get; set;}
    private string details;
    private decimal amount;

    public ReimbursementForm(){}
    
    public ReimbursementForm(string userId){
        //pull form for userId, then:
        Console.WriteLine("What is the amount of your reimbursement. \n\nAmount:");
        this.amount = decimal.Parse(Console.ReadLine());
        //save amount with ticket number for userId
        Console.WriteLine("Are there any details you would like to add.\n\nDetails:");
        this.details = Console.ReadLine();
        //save details with ticket number for userId
    }

}