using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject
{
    public class Room
    {
        public int Number { get; set; }
        public decimal BasePrice { get; set; }

        public Room(int number, decimal basePrice)
        {
            Number = number;
            BasePrice = basePrice;
        }

        public virtual decimal GetPrice(IRoomPriceStrategy priceStrategy)
        {
            return priceStrategy.CalculatePrice(this);
        }
    }
}
