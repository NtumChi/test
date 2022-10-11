namespace UserServices;
using DataAccess;
public class Employees
{
    public bool Check(string userId){
        //checks to see if userId is already part of table
        Data? check = new Data();
        string id = check.GetId(userId);
        if (id == null){
            return true;
        }else{
            return false;
        }

    }
}
