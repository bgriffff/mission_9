using Microsoft.AspNetCore.Mvc;
using mission_9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission_9.Controllers
{
    public class BuyController : Controller
    {

        private IBuyRepository repo { get; set; }
        private Basket basket { get; set; }


        public BuyController (IBuyRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Buy());
        }

        [HttpPost]
        public IActionResult Checkout(Buy buy)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                buy.Lines = basket.Items.ToArray();
                repo.SaveBuy(buy);
                basket.ClearBasket();

                return RedirectToPage("/PurchaseCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
