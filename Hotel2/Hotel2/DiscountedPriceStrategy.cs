using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject
{
    public class DiscountedPriceStrategy : IRoomPriceStrategy
    {
        public decimal CalculatePrice(Room room)
        {
            if (room is DiscountedRoom discountedRoom)
            {
                return room.BasePrice * (1 - discountedRoom.DiscountPercentage / 100);
            }
            return room.BasePrice;
        }
    }
}
