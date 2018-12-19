using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreOneWeb02.Models;
using System.IO;

namespace CoreOneWeb02.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            String result = "";
            string dbName = "data/TestDatabase.db";
            if (System.IO.File.Exists(dbName))
            {
                System.IO.File.Delete(dbName);
            }
            using (var dbContext = new MyDbContext())
            {
                //Ensure database is created
                dbContext.Database.EnsureCreated();
                if (!dbContext.Blogs.Any())
                {
                    dbContext.Blogs.AddRange(new Blog[]
                        {
                             new Blog{ BlogId=4, Title="Blog 1", SubTitle="Blog 1 subtitle" },
                             new Blog{ BlogId=5, Title="Blog 2", SubTitle="Blog 2 subtitle" },
                             new Blog{ BlogId=6, Title="Blog 3", SubTitle="Blog 3 subtitle" }
                        });
                    dbContext.SaveChanges();
                }

                foreach (var blog in dbContext.Blogs)
                {
                    result += $"BlogID={blog.BlogId}\tTitle={blog.Title}\t{blog.SubTitle}\tDateTimeAdd={blog.DateTimeAdd}\r";
                }
            }

            return Content(result);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
