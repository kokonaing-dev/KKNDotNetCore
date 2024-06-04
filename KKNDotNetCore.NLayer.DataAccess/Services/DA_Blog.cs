using KKNDotNetCore.NLayer.DataAccess.Db;
using KKNDotNetCore.NLayer.DataAccess.Models;

namespace KKNDotNetCore.NLayer.DataAccess.Services
{
    public class DA_Blog
    {
        private readonly AppDbContext _context;

        public DA_Blog()
        {
            _context = new AppDbContext();
        }

        public List<BlogModel> GetBlogs()
        {
            var blogs = _context.Blogs.ToList();
            return blogs;
        }

        public BlogModel GetBlog(int id)
        {
            var item = _context.Blogs.FirstOrDefault(b => b.BlogId == id);
            return item;
        }

        public int CreateBlog(BlogModel requestModel)
        {
            _context.Blogs.Add(requestModel);
            var result = _context.SaveChanges();
            return result;
        } 

        public int UpdateBlog(int id ,BlogModel requestModel)
        {
            var item = _context.Blogs.FirstOrDefault(b => b.BlogId == id);
            if (item is null) return 0;

            item.BlogTitle = requestModel.BlogTitle;
            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogContent = requestModel.BlogContent;

            var result = _context.SaveChanges();
            return result;
        }

        public int DeleteBlog(int id)
        {
            var item = _context.Blogs.FirstOrDefault(b => b.BlogId == id);
            if (item is null) return 0;
          
            _context.Blogs.Remove(item);
            var result = _context.SaveChanges();
            return result;
        }
    }
}
