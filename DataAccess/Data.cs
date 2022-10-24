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
        SqlCommand command = new SqlCommand("SELECT * FROM Employees;", connection);
        //command.ExecuteNonQuery
        SqlDataReader reader = command.ExecuteReader();
        if(reader.HasRows){
            while(reader.Read()){
                string id = (string) reader["UserId"];

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
    public string GetName(string userName){
        string? ans = null;
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * FROM Employees;", connection);
        SqlDataReader reader = command.ExecuteReader();
        if(reader.HasRows){
            while(reader.Read()){
                string name = (string) reader["UserName"];

                if (name == userName){
                    ans = name;
                }
            }
            connection.Close();
        }
        return ans;
    }
    public List<Object> GetEmployeeForm(string userName){
        List<Object> form = new List<Object>();
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * FROM ReimbursementForm,Employees where Status = 'Open' and UserName = @UserName;", connection);
        command.Parameters.AddWithValue("@UserName", userName);
        SqlDataReader reader = command.ExecuteReader();
        if(reader.HasRows){
            while(reader.Read()){
                int ticketNumber = (int) reader["TicketNumber"];
                decimal amount = (decimal) reader["Amount"];
                string? details = (string) reader["details"];
                string id = (string) reader["UserId"];

                form.Add(ticketNumber);
                form.Add(amount);
                if (details!=null){
                    form.Add(details);
                }else{
                    form.Add("");
                }
                form.Add(id);
            }
            connection.Close();
        }
        return form;

    }
    public List<String> GetEmployees(){
        List<String> emps = new List<String>();
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT UserName from Employees where UserId not like 'm+%';", connection);
        SqlDataReader reader = command.ExecuteReader();
        if(reader.HasRows){
            while(reader.Read()){
                string name = (string) reader["UserName"];
                emps.Add(name);
            }
            connection.Close();
        }
        return emps;
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
            connection.Close();
        }
        return forms;
    }
        public List<Object> GetForm(string userId){
        List<Object> form = new List<Object>();
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * FROM ReimbursementForm where UserId = @UserId and Status = 'Open';", connection);
        command.Parameters.AddWithValue("@UserId", userId);
        SqlDataReader reader = command.ExecuteReader();
        if(reader.HasRows){
            while(reader.Read()){
                int ticketNumber = (int) reader["TicketNumber"];
                decimal amount = (decimal) reader["Amount"];
                string? details = (string) reader["Details"];
                string id = (string) reader["UserId"];

                form.Add(ticketNumber);
                form.Add(amount);
                if (details!=null){
                    form.Add(details);
                }else{
                    form.Add("");
                }
                form.Add(id);
            }
            connection.Close();
        }
        return form;
    }
    public List<Object> GetOldForm(string userId){
        List<Object> form = new List<Object>();
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * FROM ReturnedForm where UserId = @UserId and Status = 'Open';", connection);
        command.Parameters.AddWithValue("@UserId", userId);
        SqlDataReader reader = command.ExecuteReader();
        if(reader.HasRows){
            while(reader.Read()){
                int ticketNumber = (int) reader["TicketNumber"];
                decimal amount = (decimal) reader["Amount"];
                string? details = (string) reader["Details"];
                string comment = (string) reader["Comment"];
                string id = (string) reader["UserId"];

                form.Add(ticketNumber);
                form.Add(amount);
                if (details!=null){
                    form.Add(details);
                }else{
                    form.Add("");
                }
                form.Add(comment);
                form.Add(id);
            }
            connection.Close();
        }
        return form;
    }
    public List<int> GetClosedTickets(string userId){
        List<int> tickets = new List<int>();
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT TicketNumber from ReimbursementForm where UserId = @UserId and Status = 'Closed';", connection);
        command.Parameters.AddWithValue("@UserId", userId);
        SqlDataReader reader = command.ExecuteReader();
        if(reader.HasRows){
            while(reader.Read()){
                int num = (int) reader["TicketNumber"];
                tickets.Add(num);
            }
            connection.Close();
        }
        return tickets;
        
    }
    public List<Object> GetClosedForm(int ticketNumber, string userId){
        List<Object> form = new List<Object>();
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * from ReimbursementForm where TicketNumber = @TicketNumber;", connection);
        command.Parameters.AddWithValue("@TicketNumber", ticketNumber);
        SqlDataReader reader = command.ExecuteReader();
        if(reader.HasRows){
            while(reader.Read()){
                decimal amount = (decimal) reader["Amount"];
                string? details = (string) reader["Details"];
                string id = (string) reader["UserId"];

                form.Add(ticketNumber);
                form.Add(amount);
                if (details!=null){
                    form.Add(details);
                }else{
                    form.Add("");
                }
                form.Add(id);
            }
            connection.Close();
        }
        return form;
    }
    public List<String> GetUsers(){
        List<String> users = new List<String>();
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT UserName FROM ReimbursementForm,Employees where Status = 'Open' and ReimbursementForm.UserId = Employees.UserId;", connection);
        SqlDataReader reader = command.ExecuteReader();
        if(reader.HasRows){
            while(reader.Read()){
                string name = (string) reader["UserName"];
                users.Add(name);
            }
            connection.Close();
        }
        return users;
    }
    public bool OldFormOpen(string userId){
        bool ans = false;
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * FROM ReturnedForm where UserId = @UserId and Status = 'Open';", connection);
        command.Parameters.AddWithValue("@UserId", userId);
        SqlDataReader reader = command.ExecuteReader();
         if(reader.HasRows)
            ans = true;
        else
            ans = false;
        connection.Close();
        return ans;
    }
    public void PromoteEmployee(string userName){
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("Update Employee set UserId = CONCAT('m+', UserId) where UserName = @UserName;", connection);
        command.Parameters.AddWithValue("@UserName", userName);
        command.ExecuteNonQuery();
        connection.Close();
    }
    public void Approve(int ticketNumber){
        List<String> users = new List<String>();
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("Update ReimbursementForm set Status = 'Closed' where TicketNumber = @TicketNumber;", connection);
        command.Parameters.AddWithValue("@TicketNumber", ticketNumber);
        command.ExecuteNonQuery();
        command = new SqlCommand("Update ReturnedForm set Status = 'Closed' where TicketNumber = @TicketNumber;", connection);
        command.Parameters.AddWithValue("@Ticketnumber", ticketNumber);
        command.ExecuteNonQuery();
        connection.Close();
    }
    public void Add(string userID, string userName, string password){
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("Insert into Employees(UserName, Password, UserId) values (@UserName, @Password, @UserId);", connection);
        command.Parameters.AddWithValue("@UserId", userID);
        command.Parameters.AddWithValue("@UserName", userName);
        command.Parameters.AddWithValue("@Password", password);
        command.ExecuteNonQuery();
        connection.Close();
    }
    public void AddForm(decimal amount, string details, string userId){
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("Insert into ReimbursementForm(Amount, Details, UserId, Status) values (@Amount, @Details, @UserId,'Open');", connection);
        command.Parameters.AddWithValue("@Amount", amount);
        command.Parameters.AddWithValue("@Details", details);
        command.Parameters.AddWithValue("@UserId", userId);
        command.ExecuteNonQuery();
        connection.Close();
    }
    public void SendBack(int ticketNumber, string comment, string employeeName){
        List<Object> form = new List<Object>();
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("Insert into ReturnedForm(TicketNumber, Amount, Details, Comment, Status, UserId) values (@TicketNumber, @Amount, @Details, @Comment, 'Open', @UserId);", connection);
        form = GetEmployeeForm(employeeName);
        command.Parameters.AddWithValue("@TicketNumber", (int)form[0]);
        command.Parameters.AddWithValue("@Amount", (decimal)form[1]);
        command.Parameters.AddWithValue("@Details", (string)form[2]);
        command.Parameters.AddWithValue("@Comment", comment);
        command.Parameters.AddWithValue("@UserId", (string)form[3]);
        command.ExecuteNonQuery();
        connection.Close();
    }
    public void SendBackAgain(string comment, string employeeId){
        List<Object> form = new List<Object>();
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("Update ReturnedForm set Comment = @Comment where UserId = @UserId;", connection);
        command.Parameters.AddWithValue("@Comment", comment);
        command.Parameters.AddWithValue("@UserId", employeeId);
        command.ExecuteNonQuery();
        connection.Close();
    }
    public void UpdateForm(string details, int ticketNumber){
        SqlConnection connection = new SqlConnection("Server=tcp:revserver-test.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=test-admin;Password=Sunshot7&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlCommand command = new SqlCommand("Update ReimbursementForm set Details = @Details where TicketNumber = @TicketNumber;", connection);
        command.Parameters.AddWithValue("@Details", details);
        command.Parameters.AddWithValue("@TicketNumber", ticketNumber);
        command.ExecuteNonQuery();
        connection.Close();
    }

}



//hypothetical function
//which creates own parameter, after SqlCommand function
//sqlParameter param = new SqlParameter("@isCorrect", cardToUpdate.CorrectlyAnswered == tru ? 1 : 0);
//command.Parameters.Add(param);
//command.ExecuteNonQueary;

