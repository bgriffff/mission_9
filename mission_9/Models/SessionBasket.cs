using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using mission_9.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mission_9.Models
{
    public class SessionBasket : Basket
    {
        public static Basket GetBasket(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            basket.Session = session;

            return basket;
        }


        private static int IHttpContextAccessor()
        {
            throw new NotImplementedException();
        }


        [JsonIgnore]
        public ISession Session { get; set; }

        //Overwrites and adds
        public override void AddItem(Book book, int qty)
        {
            base.AddItem(book, qty);
            // specific instance of t his object
            Session.SetJson("Basket", this);
        }

        //Remove
        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.SetJson("Basket", this);
        }


        //Clear
        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}
