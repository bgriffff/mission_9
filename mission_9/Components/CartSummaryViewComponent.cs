using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mission_9.Models;

namespace mission_9.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Buy buy;
        public CartSummaryViewComponent(Buy buyService)
        {
            buy = buyService;
        }
        public IViewComponentResult Invoke()
        {
            return View(buy);
        }
    }
}
