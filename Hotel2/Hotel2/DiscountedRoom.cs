using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject
{
    public class DiscountedRoom : Room
    {
        public decimal DiscountPercentage { get; set; }

        public DiscountedRoom(int number, decimal basePrice, decimal discountPercentage)
            : base(number, basePrice)
        {
            DiscountPercentage = discountPercentage;
        }
        public override decimal GetPrice(IRoomPriceStrategy priceStrategy)
        {
            return base.GetPrice(priceStrategy);
        }
    }
}
