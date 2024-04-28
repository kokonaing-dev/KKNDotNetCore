using KKNDotNetCore.RestApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace KKNDotNetCore.RestApi.Db
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<BlogModel> Blogs { get; set; }
    }
}