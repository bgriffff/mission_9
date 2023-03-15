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

        public BuyModel(IBookStoreRepository temp, Basket b)
        {
            //instance of your database
            repo = temp;
            basket = b;
        }

        //instance of Basket
        public Basket basket { get; set; }

        public string ReturnUrl { get; set; }


        // have to send the basket to the Get method
        public void OnGet(string returnUrl)
        {
            //returns to original url
            ReturnUrl = returnUrl ?? "/";

        }

        public IActionResult OnPost(int bookid, string returnUrl)
        {
            //get info for specific project
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookid);

            //this is a method in the Basket class
            basket.AddItem(b, 1);


            //takes you back to where you were
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            //removes item
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
