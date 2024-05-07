using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KKNDotNetCore.Shared.AdoDotNetService;

namespace KKNDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;

        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<T> Query<T>(string query , params AdoDotNetParameter[]? parameters )
        {
            SqlConnection connection = new SqlConnection( _connectionString );
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            if( parameters is not null && parameters.Length > 0)
            {
                //foreach( var item in parameters )
                //{
                //    command.Parameters.AddWithValue(item.Name, item.Value);
                //}

                //var parametersArray = parameters.Select(item => new SqlParameter(item.Name,item.Value)).ToArray();
                //command.Parameters.AddRange(parametersArray);

                command.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());
            }
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            string jsonString = JsonConvert.SerializeObject(dt); // C# to Json
            List<T> list = JsonConvert.DeserializeObject<List<T>>(jsonString)!; // Json to C# 

            return list;
        }

        public T QueryFirstOrDefault<T>(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                command.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());
            }
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            string jsonString = JsonConvert.SerializeObject(dt); // C# to Json
            List<T> list = JsonConvert.DeserializeObject<List<T>>(jsonString)!; // Json to C# 

            return list[0];
        }

        public int Execute(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                command.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());
            }
            var result = command.ExecuteNonQuery();

            connection.Close();

            return result;
        }

        public class AdoDotNetParameter
        {
            public string Name { get; set; }
            public object Value { get; set; }

            public AdoDotNetParameter()
            {
            }

            public AdoDotNetParameter(string name, object value)
            {
                Name = name;
                Value = value;
            }

        }

    }

    //extension
    public static class AdoDotNetParameterListExtension
    {
        public static List<AdoDotNetParameter> Add(this List<AdoDotNetParameter> lst, string name, object value)
        {
            lst.Add(new AdoDotNetParameter(name, value));
            return lst;
        }
    }

}
