using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission_9.Models
{
    public interface IBuyRepository
    {

        IQueryable<Buy> Buy { get; }

        void SaveBuy(Buy buy);
    }
}
