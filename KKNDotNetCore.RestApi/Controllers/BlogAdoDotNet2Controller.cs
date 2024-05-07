using KKNDotNetCore.RestApi.Models;
using KKNDotNetCore.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static KKNDotNetCore.Shared.AdoDotNetService;

namespace KKNDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService =
            new AdoDotNetService(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            var lst = _adoDotNetService.Query<BlogModel>(query);
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId";
            var item =
                _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));
            if (item is null)
            {
                return NotFound("No data found.");
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel model)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogTitle", model.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", model.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", model.BlogContent)
                );

            string message = result > 0 ? "Create Successfull !" : "Create Failed !";

            return Ok(message);
            //return StatusCode(500, "Some Error");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                           WHERE BlogId = @BlogId";
           
            int result = _adoDotNetService.Execute(query,new AdoDotNetParameter("@BlogId",id));

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            return Ok(message);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel model)
        {

            string query = @"UPDATE [dbo].[Tbl_Blog]
                    SET [BlogTitle] = @BlogTitle
                        ,[BlogAuthor] = @BlogAuthor
                        ,[BlogContent] = @BlogContent
                     WHERE BlogId = @BlogId";

            int result = _adoDotNetService.Execute(query,
               new AdoDotNetParameter("@BlogId", id),
               new AdoDotNetParameter("@BlogTitle", model.BlogTitle),
               new AdoDotNetParameter("@BlogAuthor", model.BlogAuthor),
               new AdoDotNetParameter("@BlogContent", model.BlogContent)
               );

            string message = result > 0 ? "Updating Successful" : "Updating Fail";
            return Ok(message);
        }


        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            
            string conditions = string.Empty;
            List<AdoDotNetParameter> parameters = new List<AdoDotNetParameter>();

            #region Patch Validation Conditions

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += " [BlogTitle] = @BlogTitle, ";
                parameters.Add("@BlogTitle" , blog.BlogTitle);
            }

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += " [BlogAuthor] = @BlogAuthor, ";
                parameters.Add("@BlogAuthor", blog.BlogAuthor);
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += " [BlogContent] = @BlogContent, ";
                parameters.Add("@BlogContent", blog.BlogContent);
            }

            if (conditions.Length == 0)
            {
                var response = new { IsSuccess = false, Message = "No data found." };
                return NotFound(response);
            }

            #endregion

            parameters.Add(new AdoDotNetParameter("@BlogId", id));

            conditions = conditions.Substring(0,conditions.Length - 2);
            string query = $@"UPDATE [dbo].[Tbl_Blog] SET {conditions} WHERE BlogId = @BlogId";

            int result = _adoDotNetService.Execute(query,parameters.ToArray());
            
            string message = result > 0 ? "Patch Updating Successful." : "Patch Updating Failed.";
            return Ok(message);
        }

    }
}
