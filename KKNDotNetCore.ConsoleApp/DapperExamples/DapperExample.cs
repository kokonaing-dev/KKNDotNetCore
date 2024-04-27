using Dapper;
using KKNDotNetCore.ConsoleApp.Dtos;
using KKNDotNetCore.ConsoleApp.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKNDotNetCore.ConsoleApp.DapperExamples
{
    public class DapperExample
    {

        public void Run()
        {
            //Read();
            //Edit(1);
            //Edit(15);

            //Create("titlenew", "authornew", "contentnew");
            //Update(1, "title 2", "author 2", "content 2");
            Delete(12);
        }

        private void Create(string title, string author, string content)
        {
            BlogDto blog = new BlogDto()
            {
                Blog_Title = title,
                Blog_Author = author,
                Blog_Content = content
            };
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([Blog_Title]
           ,[Blog_Author]
           ,[Blog_Content])
     VALUES
           (@Blog_Title
           ,@Blog_Author       
           ,@Blog_Content)";

            using IDbConnection db =
                        new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        private void Read()
        {
            using IDbConnection db =
                new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            List<BlogDto> list = db.Query<BlogDto>("select * from tbl_blog").ToList();
            foreach (BlogDto blog in list)
            {
                Console.WriteLine("Blog Id : " + blog.Blog_Id);
                Console.WriteLine("Blog Author : " + blog.Blog_Author);
                Console.WriteLine("Blog Title : " + blog.Blog_Title);
                Console.WriteLine("Blog Content : " + blog.Blog_Content);
                Console.WriteLine("");
            }

        }

        private void Edit(int id)
        {
            using IDbConnection db =
                new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogDto>("select * from tbl_blog where blog_id=@blog_id",
                new BlogDto { Blog_Id = id })
                .FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine(item.Blog_Id);
            Console.WriteLine(item.Blog_Title);
            Console.WriteLine(item.Blog_Author);
            Console.WriteLine(item.Blog_Content);
        }

        private void Update(int id, string content, string title, string author)
        {
            BlogDto blog = new BlogDto()
            {
                Blog_Id = id,
                Blog_Title = title,
                Blog_Author = author,
                Blog_Content = content
            };
            string query = @"UPDATE [dbo].[Tbl_Blog]
                SET [Blog_Title] = @Blog_Title
                   ,[Blog_Author] = @Blog_Author
                    ,[Blog_Content] = @Blog_Content
                WHERE Blog_Id = @Blog_Id";

            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var item = new BlogDto
            {
                Blog_Id = id,
            };
            string query = @"Delete From [dbo].[Tbl_Blog] WHERE Blog_Id = @Blog_Id";
            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);
        }

    }
}
