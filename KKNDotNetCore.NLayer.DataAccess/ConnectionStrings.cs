using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKNDotNetCore.NLayer.DataAccess
{
    public static class ConnectionStrings
    {
        public static readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTesting",
            UserID = "sa",
            Password = "root",
            TrustServerCertificate = true
        };
    }
}
