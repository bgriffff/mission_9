using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission_9.Models
{
    public class EFBuyRepository : IBuyRepository
    {
        private BookStoreContext context;

        //constructor
        public EFBuyRepository(BookStoreContext temp)
        {
            context = temp;
        }

        //gets all the entries in the buy and then getting all of the books and connects them
        public IQueryable<Buy> Buy => context.Buy.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveBuy(Buy buy)
        {
            context.AttachRange(buy.Lines.Select(x => x.Book));

            if (buy.BuyId == 0)
            {
                context.Buy.Add(buy);
            }

            context.SaveChanges();
        }
    }
}
