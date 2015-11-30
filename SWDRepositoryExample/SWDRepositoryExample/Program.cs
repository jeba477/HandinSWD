using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWDRepositoryExample.Database;
using SWDRepositoryExample.Repository;

namespace SWDRepositoryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SWDContext();
            var blogs = new Repository<Blog>(context);
            var posts = new Repository<Post>(context);
            var uow = new UnitOfWork(context);

            var blog = blogs.Insert(new Blog { Name = "post one" });
            posts.Insert(new Post { Blog_Id = blog.Id, Content = "This is content", Time = DateTime.Now });
            uow.Complete();
            

            foreach (var allBlog in blogs.GetAll())
            {
                Console.WriteLine($"Blogid: {allBlog.Id} \nBlogName: {allBlog.Name}\nPostCount: {allBlog.Posts.Count()}\nPostId: {allBlog.Posts.ElementAt(0).Id}\nPostName: {allBlog.Posts.ElementAt(0).Content}");
            }
            

            var input = Console.ReadLine();
        }
    }
}
