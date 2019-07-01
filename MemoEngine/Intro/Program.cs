using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intro
{
    class Program
    {
        static void Main()
        {
            using (var db = new BloggingContext())
            {
                var blogs = db.Blogs
                    //.Where(b => b.Rating > 3)
                    .OrderBy(b => b.Url)
                    .ToList();

                foreach (var blog in blogs)
                {
                    Console.WriteLine($"{blog.BlogId} - {blog.Url}");
                }
            }
        }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MemoEngine;Trusted_Connection=True;");
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
