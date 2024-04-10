using System.Data;
using System.Data.SqlClient;
using System.Text;

Console.WriteLine("Hello, World!");

SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
{
    DataSource = "kkn" ,
    InitialCatalog = "DotNetTesting" ,
    UserID = "sa",
    Password =  "root"
};
SqlConnection connection = new SqlConnection(builder.ConnectionString);
connection.Open();

string sql = "Select * From Tbl_Blog";
SqlCommand cmd = new SqlCommand(sql, connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt);

connection.Close();

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog Id => " + dr["Blog_Id"]);
    Console.WriteLine("Blog Title => " + dr["Blog_Title"]);
    Console.WriteLine("Blog Author => " + dr["Blog_Author"]);
    Console.WriteLine("Blog Content => " + dr["Blog_Content"]);
    Console.WriteLine("=========================");

}

Console.ReadKey();
