using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mission_9.Infrastructure;
using mission_9.Models;

namespace mission_9.Pages
{
    public class BuyModel : PageModel
    {
        private IBookStoreRepository repo { get; set; }

        public BuyModel(IBookStoreRepository temp)
        {
            //instance of your database
            repo = temp;
        }

        //instance of Basket
        public Basket basket { get; set; }

        public string ReturnUrl { get; set; }


        // have to send the basket to the Get method
        public void OnGet(string returnUrl)
        {
            //returns to original url
            ReturnUrl = returnUrl ?? "/";

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookid, string returnUrl)
        {
            //get info for specific project
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookid);

            //get the session Json or Have to set up a new instance of a basket. ?? means null coalescing operator. returns value of left hand operand if null otherwise
            // it evaluates the right-hand operand and returns its result
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();

            //this is a method in the Basket class
            basket.AddItem(b, 1);

            //sends the basket
            HttpContext.Session.SetJson("basket", basket);

            //takes you back to where you were
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
