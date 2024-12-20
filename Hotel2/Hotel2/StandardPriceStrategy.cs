using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject
{
    public  class StandardPriceStrategy : IRoomPriceStrategy
    {
        public decimal CalculatePrice(Room room)
        {
            return room.BasePrice;
        }
    }
}
