﻿using KKNDotNetCore.ConsoleApp.Dtos;
using KKNDotNetCore.ConsoleApp.Service;
using Microsoft.EntityFrameworkCore;

namespace KKNDotNetCore.ConsoleApp.EFCoreExamples
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<BlogDto> Blogs { get; set; }
    }
}