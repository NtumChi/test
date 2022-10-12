namespace DataAccess;
using Microsoft.Data.SqlClient;
public class Data
{
    public string GetEId(string userId){
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
        SqlCommand command = new SqlCommand("SELECT * FROM Employees;", connection);
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

    public string GetMId(string userId){
        string? ans = null;
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();

        SqlCommand command = new SqlCommand("SELECT * FROM Managers;", connection);
        SqlDataReader reader = command.ExecuteReader();
        if(reader.HasRows){
            while(reader.Read()){
                string id = (string) reader["UserId"];
                decimal amount = (decimal) reader["Amount"];
                string details = (string) reader["details"];

                if (id == userId){
                    ans = id;
                }
            }
            connection.Close();
        }
        return ans;
    }
}



//hypothetical function
//which creates own parameter, after SqlCommand function
//sqlParameter param = new SqlParameter("@isCorrect", cardToUpdate.CorrectlyAnswered == tru ? 1 : 0);
//command.Parameters.Add(param);
//command.ExecuteNonQueary;

