using KKNDotNetCore.MvcApp2.Db;
using KKNDotNetCore.MvcApp2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KKNDotNetCore.MvcApp2.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // select * from Tbl_Blog with (nolock)

            var lst = await _context.Blogs
                .AsNoTracking()
                .OrderByDescending(x => x.BlogId)
                .ToListAsync();
            return View(lst);
        }

        [HttpGet]
        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("Create");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> BlogCreate(BlogModel blog)
        {
            await _context.Blogs.AddAsync(blog);
            var result = await _context.SaveChangesAsync();
            //return View("BlogCreate");
            return Redirect("/Blog");
            //return RedirectToAction("Index", "Blog");
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> BlogEdit(int id)
        {
            var item = await _context.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
            {
                return Redirect("/Blog");
            }

            return View("Edit", item);
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
        {
            var item = await _context.Blogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
            {
                return Redirect("/Blog");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            _context.Entry(item).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return Redirect("/Blog");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> BlogDelete(int id)
        {
            var item = await _context.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
            {
                return Redirect("/Blog");
            }

            _context.Blogs.Remove(item);
            await _context.SaveChangesAsync();

            return Redirect("/Blog");
        }
    }
}
