using Microsoft.AspNetCore.Mvc;
using System;
using mission_9.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mission_9.Models.ViewModels;

namespace mission_9.Controllers
{
    public class HomeController : Controller
    {
        private IBookStoreRepository repo;

        public HomeController(IBookStoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                //Skips the first 5
                .Skip((pageNum - 1) * pageSize)
                //returns a specific number of results
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = repo.Books.Count(),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
