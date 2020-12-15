using DragonBlog.Data;
using DragonBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBlog.Utilities
{
    public class BlogHelper
    {
        public static List<Blog> GetBlogs(ApplicationDbContext db)
        {
            return db.Blog.ToList();
        }
    }
}
