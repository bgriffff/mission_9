using Microsoft.AspNetCore.Mvc;
using mission_9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission_9.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IBookStoreRepository repo { get; set; }

        public CategoriesViewComponent(IBookStoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["Category"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
