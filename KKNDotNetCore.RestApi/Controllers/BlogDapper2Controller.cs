using Dapper;
using KKNDotNetCore.RestApi.Models;
using KKNDotNetCore.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace KKNDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapper2Controller : ControllerBase
    {
        private readonly DapperService _dapperServie =
            new DapperService(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";

            var lst = _dapperServie.Query<BlogModel>(query);
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            //using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            //string query = "select * from tbl_blog where blogid=@blogid";
            //var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found...");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                   ([BlogTitle]
                   ,[BlogAuthor]
                   ,[BlogContent])
             VALUES
                   (@BlogTitle
                   ,@BlogAuthor       
                   ,@BlogContent)";

           int result = _dapperServie.Execute(query,blog);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";

            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel model)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found...");
            }
            model.BlogId = id;
            string query = @"UPDATE [dbo].[Tbl_Blog]
                SET [BlogTitle] = @BlogTitle
                   ,[BlogAuthor] = @BlogAuthor
                    ,[BlogContent] = @BlogContent
                WHERE BlogId = @BlogId";

            int result = _dapperServie.Execute(query , model);

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id , BlogModel model)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found...");
            }
            model.BlogId = id;
            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(model.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(model.BlogAuthor))
            {
                conditions += "[BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(model.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent, ";
            }
            if(conditions.Length == 0)
            {
                return NotFound("No Data");
            }
            conditions = conditions.Substring(0 , conditions.Length - 2 );
            string query = $@"UPDATE [dbo].[Tbl_Blog]
                SET {conditions} WHERE BlogId = @BlogId";

            int result = _dapperServie.Execute(query,model);

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found...");
            }
            string query = @"Delete From [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";
            int result = _dapperServie.Execute(query, item);

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            return Ok(message);
        }

        private BlogModel? FindById(int id)
        {
            string query = "select * from tbl_blog where blogid=@blogid";
            var item = _dapperServie.QueryFirstOrDefault<BlogModel>(query, new BlogModel { BlogId = id });
            return item;
        }
    }
}
