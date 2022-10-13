namespace UserServices;
using Data;
using System.Collections.Generic;
public class ManagerMenu{

    private string userId;
    public ManagerMenu(string userId){
        Console.WriteLine("Manager Menu:\n\nView Reimbursement tickets(1)\nUpdate Employee Status(2)");
        string ans = Console.ReadLine();
        if (ans.Equals("1")){
            //lookup open reimbursement tickets
            //close tickets once done
            ReimbursementTickets();
        }else if (ans.Equals("2")){
            //retrieve list of employees
            UpdateEmployeeStatus();
        }
    }
    public void UpdateEmployeeStatus(){

    }
    public void ReimbursementTickets(){
        //do lookup of ticketform
        List <String> data = new List<String>();
        Data forms = new Data();
        data = forms.GetUsers();
        //write info for interface
        while(data.Count()>0){
            Console.Write(data[0]);
            data.RemoveAt(0);
        }
    }
}