using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DragonBlog.Models;

namespace DragonBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext<BlogUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DragonBlog.Models.Blog> Blog { get; set; }
        public DbSet<DragonBlog.Models.Post> Post { get; set; }
        public DbSet<DragonBlog.Models.Comment> Comment { get; set; }
        public DbSet<DragonBlog.Models.Tag> Tag { get; set; }
    }
}
