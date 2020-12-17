using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DragonBlog.Models;
using DragonBlog.Data;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace DragonBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index(int? page, string searchStr)
        {
            ViewBag.Search = searchStr;
            var blogList = IndexSearch(searchStr);

            int pageSize = 5;// display three blog posts at a time on this page 
            int pageNumber = (page ?? 1);


            //var model = _context.Post.Include(p => p.Blog);
            //var listPosts = _context.Post.AsQueryable(); 
            //return View(listPosts.OrderByDescending(p => p.Created).ToPagedList(pageNumber, pageSize));
            return View(blogList.ToPagedList(pageNumber, pageSize));
        }

        public IQueryable<Post> IndexSearch(string searchStr)
        {
            IQueryable<Post> result = null;
            if (searchStr != null)
            {
                result = _context.Post.AsQueryable();
                result = result.Where(p => p.Title.Contains(searchStr) ||
                                        p.Content.Contains(searchStr) ||
                                        p.Comments.Any(c => c.Content.Contains(searchStr) ||
                                                        c.Author.FirstName.Contains(searchStr) ||
                                                        c.Author.LastName.Contains(searchStr) ||
                                                        c.Author.DisplayName.Contains(searchStr) ||
                                                        c.Author.Email.Contains(searchStr)));
            }
            else
            {
                result = _context.Post.AsQueryable();
            }

            return result.OrderByDescending(p => p.Created);

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
