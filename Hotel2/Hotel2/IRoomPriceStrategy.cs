﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject
{
    public interface IRoomPriceStrategy
    {
        decimal CalculatePrice(Room room);
    }
}