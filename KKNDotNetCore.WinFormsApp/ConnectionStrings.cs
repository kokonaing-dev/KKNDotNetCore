using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKNDotNetCore.WinFormsApp
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
