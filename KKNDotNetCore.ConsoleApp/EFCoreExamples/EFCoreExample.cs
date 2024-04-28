using KKNDotNetCore.ConsoleApp.Dtos;

namespace KKNDotNetCore.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        private readonly AppDbContext _context = new AppDbContext();
        public void Run()
        {
            Read();
            //Edit(1);
            //Edit(15);

            //Create("titlenew", "authornew", "contentnew");
            //Update(1, "ef title", "author 2", "content 2");
            //Delete(13);
        }

        private void Create(string title, string author, string content)
        {
            BlogDto blog = new BlogDto()
            {
                Blog_Title = title,
                Blog_Author = author,
                Blog_Content = content
            };

            _context.Add(blog);
            int result = _context.SaveChanges();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        private void Read()
        {
            var list = _context.Blogs.ToList();

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

            var item = _context.Blogs.FirstOrDefault(blog => blog.Blog_Id == id);
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
            var item = _context.Blogs.FirstOrDefault(blog => blog.Blog_Id == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            item.Blog_Title = title;
            item.Blog_Author = author;
            item.Blog_Content = content;

            int result = _context.SaveChanges();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var item = _context.Blogs.FirstOrDefault(blog => blog.Blog_Id == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            _context.Remove(item);
            int result = _context.SaveChanges();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);
        }

    }
}
