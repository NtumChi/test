namespace UserServices;
using Data;
using System.Collections.Generic;
public class EmployeeMenu
{
    public EmployeeMenu(){}
    public EmployeeMenu(string userId, string userName){
        Data reimbursement = new Data();
        if(reimbursement.OldFormOpen(userId)==true){
            //display old ticket info with comment
            List<Object> form = new List<Object>();
            form = reimbursement.GetOldForm(userId);
            Console.WriteLine("Ticket Number: "+ (int)form[0]);
            Console.WriteLine("Amount: " + (decimal)form[1]);
            Console.WriteLine("Details: " + (string)form[2]);
            Console.WriteLine("Comments: " + (string)form[3]);
            Update((decimal)form[1], (string)form[2],(string)form[4]);

        }
        Console.WriteLine("Hello " + userName + "\n\nCreate new reimbursement ticket(1)\nView old tickets(2)");
        string ans = Console.ReadLine();
        if(ans == "1"){
            ReimbursementForm form = new ReimbursementForm(userId);
        }else{
            GetClosedTickets(userId);
        }
    }
    public bool OldFormOpen(string userId){
        Data reimbursement = new Data();
        if(reimbursement.OldFormOpen(userId)==true){
            return true;
        }
        return false;
    }
    public List<Object> GetOldForm(string userId){
        Data reimbursement = new Data();
        return reimbursement.GetOldForm(userId);
    }
    public bool Exists(string userId){
        //checks to see if userId is already part of table
        Data? check = new Data();
        string? id = check.GetId(userId);
        if (id != null){
            return true;
        }else{
            return false;
        }
    }
    public bool nameExists(string userName){
        Data? check = new Data();
        string? id = check.GetName(userName);
        if(id != null){
            return true;
        }else{
            return false;
        }
    }

    public void Add(string userID, string userName, string password){
        Data add = new Data();
        add.Add(userID, userName, password);
    }
    public void Update(decimal amount, string details, string userId){
        Console.WriteLine("Would you like to update the Amount? Yes/No");
        string ans = Console.ReadLine();
        int ticketNumber = 0;
        if (ans == "Yes"){
            Console.WriteLine("Whats the ticket number?");
            ticketNumber = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Would you like to update the Details? Yes/No");
        ans = Console.ReadLine();
        if (ans == "Yes"){
            Console.WriteLine("Please enter new Details.");
            details = Console.ReadLine();
        }
        Data reimbursement= new Data();
        reimbursement.UpdateForm(details, ticketNumber);
    }

    public void UpdateForm(string details, int ticketNumber){
        Data reimbursement = new Data();
        reimbursement.UpdateForm(details, ticketNumber);
    }

    public List<int> GetClosedTickets(string userId){
        Data forms = new Data();
        List<int> tickets = new List<int>();
        List<Object> form = new List<Object>();
        tickets = forms.GetClosedTickets(userId);
        
        return tickets;

        /*Console.WriteLine("Which ticket would you like to view?");
        while(tickets.Count()>0){
            Console.WriteLine(tickets[0]);
            tickets.RemoveAt(0);
        }
        int ans = int.Parse(Console.ReadLine());
        form = forms.GetClosedForm(ans,userId);
        Console.WriteLine("TicketNumber: " + (int)form[0]);
        Console.WriteLine("Amount: " + (decimal) form[1]);
        Console.WriteLine("Details: " + (string) form[2]);*/
    }

    public List<Object> GetClosedForm(int ticketNumber, string userId){
        Data form = new Data();
        return form.GetClosedForm(ticketNumber,userId);
    }
}
