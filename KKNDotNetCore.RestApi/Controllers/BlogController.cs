using KKNDotNetCore.RestApi.Db;
using KKNDotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KKNDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // api/blog => endpoint

    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BlogController() { 
            _context = new AppDbContext();  
        }

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _context.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.Blog_Id == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _context.Blogs.Add(blog);
            var result = _context.SaveChanges();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.Blog_Id == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            item.Blog_Title = blog.Blog_Title;
            item.Blog_Author = blog.Blog_Author;
            item.Blog_Content = blog.Blog_Content;
            var result = _context.SaveChanges();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.Blog_Id == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            if (!string.IsNullOrEmpty(blog.Blog_Title))
            {
                item.Blog_Title = blog.Blog_Title;
            }
            if (!string.IsNullOrEmpty(blog.Blog_Author))
            {
                item.Blog_Author = blog.Blog_Author;
            }
            if (!string.IsNullOrEmpty(blog.Blog_Content))
            {
                item.Blog_Content = blog.Blog_Content;
            }
            var result = _context.SaveChanges();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.Blog_Id == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            _context.Blogs.Remove(item);
            var result = _context.SaveChanges();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            return Ok(message);
        }

    }
}
