namespace UserServices;
public class ManagerMenu{

    public ManagerMenu(string userId){
        Console.WriteLine("Manager Menu:\n\nView Reimbursement tickets(1)\nUpdate Employee Status(2)");
        string ans = Console.ReadLine();
        if (ans.Equals("1",StringComparison.OrdinalIgnoreCase )){
            //lookup open reimbursement tickets
            //close tickets once done
        }else if (ans.Equals("2",StringComparison.OrdinalIgnoreCase )){
            //retrieve list of employees
        }
    }
    public void UpdateEmployeeStatus(string userId){

    }
    public void ReimbursementTickets(){

    }
}