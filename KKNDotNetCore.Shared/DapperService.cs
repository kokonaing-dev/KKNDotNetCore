using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace KKNDotNetCore.Shared
{
    public class DapperService
    {
        private readonly string _connectionString;

        public DapperService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<T> Query<T>(string query , object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            //if(param == null)
            //{
            //    var lst1 = db.Query<T>(query, param).ToList();

            //}
            //else
            //{
            //    var lst2 = db.Query<T>(query).ToList();

            //}
            var lst = db.Query<T>(query,param).ToList();
            return lst;
        }

        public T QueryFirstOrDefault<T>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var item = db.Query<T>(query, param).FirstOrDefault();
            return item!;
        }



        public int Execute(string query , object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = db.Execute(query,param);
            return result;
        }


    }
}
