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
            Read();
            //Edit(1);
            //Edit(15);

            //Create("titlenew", "authornew", "contentnew");
            //Update(1, "title 2", "author 2", "content 2");
            //Delete(12);
        }

        private void Create(string title, string author, string content)
        {
            BlogDto blog = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor       
           ,@BlogContent)";

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
                Console.WriteLine("Blog Id : " + blog.BlogId);
                Console.WriteLine("Blog Author : " + blog.BlogAuthor);
                Console.WriteLine("Blog Title : " + blog.BlogTitle);
                Console.WriteLine("Blog Content : " + blog.BlogContent);
                Console.WriteLine("");
            }

        }

        private void Edit(int id)
        {
            using IDbConnection db =
                new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogDto>("select * from tbl_blog where blogid=@blogid",
                new BlogDto { BlogId = id })
                .FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        private void Update(int id, string content, string title, string author)
        {
            BlogDto blog = new BlogDto()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"UPDATE [dbo].[Tbl_Blog]
                SET [BlogTitle] = @BlogTitle
                   ,[BlogAuthor] = @BlogAuthor
                    ,[BlogContent] = @BlogContent
                WHERE BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var item = new BlogDto
            {
                BlogId = id,
            };
            string query = @"Delete From [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);
        }

    }
}
