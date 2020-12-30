using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreProje.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        BlogdbContext c = new BlogdbContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        public IActionResult Index()
        {
            var list = c.Blogs.ToList();
            foreach(var blog in list)
            {
                blog.Admin = c.Admins.Find(blog.AdminId);
            }
            return View(list);
        }
        public IActionResult Post(int? Id)
        {           

            var blog = c.Blogs.Find(Id);
            blog.Admin = c.Admins.Find(blog.AdminId);
           
            return View(blog);
        }
        public IActionResult Category()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }
        public IActionResult Tours()
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
