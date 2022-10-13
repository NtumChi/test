namespace UserServices;
using Data;
public class Employee
{
    public bool Exists(string userId){
        //checks to see if userId is already part of table
        Data? check = new Data();
        string id = check.GetId(userId);
        if (id != null){
            return true;
        }else{
            return false;
        }
    }

    public void Add(string userId, string userName, string password){
        Data add = new Data();
        add.Add(userId, userName, password);
    }
}
