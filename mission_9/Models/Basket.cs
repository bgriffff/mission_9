using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission_9.Models
{
    public class Basket
    {
        // this part declares                               this part instanciates
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem(Book book, int qty)
        {
            BasketLineItem line = Items
                // got find the project associated with the ID
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                //adds a new entry in the Item if there wasn't a project
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        public double CalculateTotal()
        {
            // has a default of always donating 25$
            double sum = Items.Sum(x => x.Quantity * 25);

            return sum;
        }

        public class BasketLineItem
        {
            public int LineID { get; set; }

            public Book Book { get; set; }

            public int Quantity { get; set; }

        }
    }
}
