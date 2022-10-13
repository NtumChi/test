namespace Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
public class Data
{
    public string GetId(string userId){
        //List<ReimbursementForm> forms = new List<ReimbursementForm>();
        //connect to database
            //define connection, tell where to find server and credentials(provided via connection string)
            //open connection
        //assemble query/sql interested in running
        //execute statements
        //get results
        //process results, so app can understand it
        //close connection
        //return results to caller
        string? ans = null;
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        //replace select with "insert into <table> (columns) values (@inputname)"
        //then command.Parameters.AddWithValue("@inputname", input);
        SqlCommand command = new SqlCommand("SELECT * FROM ReimbursementForm;", connection);
        //command.ExecuteNonQuery
        SqlDataReader reader = command.ExecuteReader();
        if(reader.HasRows){
            while(reader.Read()){
                string id = (string) reader["UserId"];
                decimal amount = (decimal) reader["Amount"];
                string details = (string) reader["details"];

                if (id == userId){
                    ans = id;
                }
                //ReimbursementForm form = new ReimbursementForm{
                //    id = id,
                //    amount = amount,
                //    details = details
                //}
                //forms.add(form);

            }

            connection.Close();
            //return forms;
        }
        return ans;
    }
    public List<Object> GetForms(){
        List<Object> forms = new List<Object>();
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * FROM ReimbursementForm where Status = 'Open';", connection);
        SqlDataReader reader = command.ExecuteReader();
        if(reader.HasRows){
            while(reader.Read()){
                string id = (string) reader["UserId"];
                decimal amount = (decimal) reader["Amount"];
                string? details = (string) reader["details"];
                int ticketNumber = (int) reader["TicketNumber"];

                forms.Add(id);
                forms.Add(amount);
                if (details!=null){
                    forms.Add(details);
                }else{
                    forms.Add("");
                }
                forms.Add(ticketNumber);
            }
        }
        return forms;
    }
    public List<String> GetUsers(){
        List<String> users = new List<String>();
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT UserName FROM Employees;", connection);
        SqlDataReader reader = command.ExecuteReader();
        if(reader.HasRows){
            while(reader.Read()){
                string name = (string) reader["UserName"];
                users.Add(name);
            }
        }
        return users;
    }
    public void Add(string userId, string userName, string password){
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("Insert into Employees(UserName, Password, UserId) values (@UserName, @Password, @UserId);", connection);
        command.Parameters.AddWithValue("@UserId", userId);
        command.Parameters.AddWithValue("@UserName", userName);
        command.Parameters.AddWithValue("@Password", password);
        command.ExecuteNonQuery();
    }
    public void AddForm(decimal amount, string details, string userId){
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("Insert into ReimbursementForm(Amount, Details, UserId, Status) values (@Amount, @Details, @UserId,'Open');", connection);
        command.Parameters.AddWithValue("@Amount", amount);
        command.Parameters.AddWithValue("@Details", details);
        command.Parameters.AddWithValue("@UserId", userId);
        command.ExecuteNonQuery();
    }

}



//hypothetical function
//which creates own parameter, after SqlCommand function
//sqlParameter param = new SqlParameter("@isCorrect", cardToUpdate.CorrectlyAnswered == tru ? 1 : 0);
//command.Parameters.Add(param);
//command.ExecuteNonQueary;

