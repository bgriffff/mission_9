using Microsoft.AspNetCore.Mvc;
using mission_9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission_9.Components
{
    public class TypesViewComponents : ViewComponent
    {
        private IBookStoreRepository repo { get; set; }

        public TypesViewComponents(IBookStoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["category"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
