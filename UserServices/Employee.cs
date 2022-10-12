namespace UserServices;
using DataAccess;
public class Employee
{
    public bool EmployeeExists(string userId){
        //checks to see if userId is already part of table
        Data? check = new Data();
        string id = check.GetEId(userId);
        if (id != null){
            return true;
        }else{
            return false;
        }

    }
    public bool ManagerExists(string userId){
        
        Data? check = new Data();
        string id = check.GetMId(userId);
        if (id != null){
            return true;
        }else{
            return false;
        }


    }
}
