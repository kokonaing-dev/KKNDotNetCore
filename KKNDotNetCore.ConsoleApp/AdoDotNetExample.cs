using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKNDotNetCore.ConsoleApp
{
    public class AdoDotNetExample
    {

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTesting",
            UserID = "sa",
            Password = "root"
        };



        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("Connection Opened...");
            Console.WriteLine("...");

            string query = @"SELECT [Blog_Id]
                  ,[Blog_Title]
                  ,[Blog_Author]
                  ,[Blog_Content]
              FROM [dbo].[Tbl_Blog]";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            Console.WriteLine(" ");
            Console.WriteLine("Connection Closing...");
            connection.Close();
            Console.WriteLine("Connection Closed...");
            Console.WriteLine(" ");


            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Title : " + dr["Blog_Title"]);
                Console.WriteLine("Author : " + dr["Blog_Author"]);
                Console.WriteLine("Content : " + dr["Blog_Content"]);
                Console.WriteLine(" ");
            }
        }

        public void Create(string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            String query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([Blog_Title]
           ,[Blog_Author]
           ,[Blog_Content])
     VALUES
           (@Blog_Title
           ,@Blog_Author
           ,@Blog_Content)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Blog_Title", title);
            cmd.Parameters.AddWithValue("@Blog_Author", author);
            cmd.Parameters.AddWithValue("@Blog_Content", content);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Create Successfull !" : "Create Failed !";
            Console.WriteLine(message);
            Console.ReadKey();
        }

        public void Update(int id, string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [Blog_Title] = @Blog_Title
      ,[Blog_Author] = @Blog_Author
      ,[Blog_Content] = @Blog_Content
 WHERE Blog_Id = @Blog_Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Blog_Id", id);
            command.Parameters.AddWithValue("@Blog_Title", title);
            command.Parameters.AddWithValue("@Blog_Author", author);
            command.Parameters.AddWithValue("@Blog_Content", content);
            int result = command.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Updating Successful" : "Updating Fail";
            Console.WriteLine(message);
        }

        public void Edit(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            String query = "SELECT * FROM Tbl_Blog WHERE Blog_Id = @Blog_Id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@Blog_Id", id);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Not Found !");
                return;
            }
            DataRow dr = dt.Rows[0];
            Console.WriteLine("Id : " + dr["Blog_Id"]);
            Console.WriteLine("Title : " + dr["Blog_Title"]);
            Console.WriteLine("Author : " + dr["Blog_Author"]);
            Console.WriteLine("Content : " + dr["Blog_Content"]);
            Console.ReadKey();
        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            String query = @"DELETE FROM Tbl_Blog WHERE Blog_Id = @Blog_Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Blog_Id", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Delete Successfull !" : "Delete Failed !";
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }

}
