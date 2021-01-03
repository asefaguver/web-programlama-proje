using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreProje.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace CoreProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHtmlLocalizer<HomeController> _localizer;
        private readonly ILogger<HomeController> _logger;

        BlogdbContext c = new BlogdbContext();

        public HomeController(ILogger<HomeController> logger, IHtmlLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var test = _localizer["TopDestinations"];
            ViewData["TopDestinations"] = test;
            var list = c.Blogs.ToList();
            foreach(var blog in list)
            {
                blog.Admin = c.Admins.Find(blog.AdminId);
            }
            return View(list);
        }
        //public IActionResult Comment(int? Id)
        //{           

        //    var blog = c.Blogs.Find(Id);
        //    blog.Admin = c.Admins.Find(blog.AdminId);

        //    return View(blog);
        //}

        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            return LocalRedirect(returnUrl);
        }

        BlogYorum by = new BlogYorum();
        public IActionResult Post(int? id) // eski com
        {
            if (id == null)
            {
                return NotFound();
            }
            //var yorum = await c.Yorums
            //    .Include(y => y.Admin)
            //    .Include(y => y.Blog)
            //    .FirstOrDefaultAsync(m => m.YorumId == id);
            //if (yorum == null)
            //{
            //    return NotFound();
            //}
            by.Deger1 = c.Blogs.Where(x => x.BlogId == id).ToList();
            by.Deger2 = c.Yorums.Where(x => x.BlogId == id).ToList();
            ViewBag.deger = id;
            return View(by);
        }
        [HttpPost]
        public async Task<IActionResult> Post([Bind("YorumId,Yicerik,AdminId,BlogId")] Yorum yorum)
        {
            yorum.Tarih = DateTime.Now;
            if (ModelState.IsValid)
            {
                c.Add(yorum);
                await c.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(c.Admins, "AdminId", "AdminId", yorum.AdminId);
            ViewData["BlogId"] = new SelectList(c.Blogs, "BlogId", "BlogId", yorum.BlogId);
            return View(yorum);
            //Yorum yeniyorum = new Yorum();
            //yeniyorum.Yicerik = txt;
            //yeniyorum.YorumId = id;
            //yeniyorum.AdminId = AdminId;
            //yeniyorum.BlogId = BlogId;
            //yeniyorum.Tarih = DateTime.Now;
            //c.Add(yeniyorum);
            //c.SaveChanges();
            //return View();

        }
        public IActionResult Category()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }
        public IActionResult Tours()
        {
            var list = c.Blogs.ToList();
            foreach (var blog in list)
            {
                blog.Admin = c.Admins.Find(blog.AdminId);
            }
            return View(list);
        }
        public IActionResult YiciTour()
        {
            var list = c.Blogs.ToList();
            foreach (var blog in list)
            {
                blog.Admin = c.Admins.Find(blog.AdminId);
            }
            return View(list);

        }
        public IActionResult YdisiTour()
        {
            var list = c.Blogs.ToList();
            foreach (var blog in list)
            {
                blog.Admin = c.Admins.Find(blog.AdminId);
            }
            return View(list);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
