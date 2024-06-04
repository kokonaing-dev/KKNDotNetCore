using KKNDotNetCore.NLayer.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace KKNDotNetCore.NLayer.DataAccess.Db
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