using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelProject
{
    public class Hotel
    {
        private List<Room> Rooms = new List<Room>();

        
        public void AddRoom(Room room)
        {
            if (RoomDouble(room))
            {
                Rooms.Add(room);
            }
            else
            {
                MessageBox.Show("Есть такой номер");
            }
        }

        public bool RoomDouble(Room room)
        {
            foreach (Room rm in Rooms)
            {
                if (rm.Number == room.Number)
                {
                    return false;
                }
            } 
            return true;
        }
        public decimal CalculateAveragePrice(IRoomPriceStrategy priceStrategy)
        {
            if (Rooms.Count == 0)
            {
                MessageBox.Show("В отеле нет номеров.");
            }
            else
            {
                return Rooms.Average(room => room.GetPrice(priceStrategy));
            }
            return 0;
        }
        public List<object> GetRoomData(IRoomPriceStrategy priceStrategy)
        {
            return Rooms.Select(room =>
            {
                var discountedRoom = room as DiscountedRoom;
                return new
                {
                    RoomNumber = room.Number,
                    BasePrice = room.BasePrice,
                    DiscountPercentage = discountedRoom?.DiscountPercentage ?? 0,
                    FinalPrice = room.GetPrice(priceStrategy)
                };
            }).ToList<object>();
        }
        public void SaveToFile(string filePath, IRoomPriceStrategy priceStrategy)
        {
            var lines = new List<string>
    {
        "RoomNumber,BasePrice,DiscountPercentage,FinalPrice" 
    };

            lines.AddRange(Rooms.Select(room =>
            {
                var discountedRoom = room as DiscountedRoom;
                return string.Join(",",
                    room.Number,
                    room.BasePrice.ToString("F2"),
                    (discountedRoom?.DiscountPercentage ?? 0).ToString("F3"),
                    room.GetPrice(priceStrategy).ToString("F4"));
            }));

            System.IO.File.WriteAllLines(filePath, lines);
        }
        public void LoadFromFile(string filePath)
        {
            var lines = System.IO.File.ReadAllLines(filePath);

            
            if (lines.Length < 2) return;

            Rooms.Clear(); 

            foreach (var line in lines.Skip(1))
            {
                var columns = line.Split(',');

                if (columns.Length >= 4 &&
                    int.TryParse(columns[0], out int roomNumber) &&
                    decimal.TryParse(columns[1], out decimal basePrice) &&
                    decimal.TryParse(columns[2], out decimal discountPercentage))
                {
                    if (discountPercentage > 0)
                    {
                        Rooms.Add(new DiscountedRoom(roomNumber, basePrice, discountPercentage));
                    }
                    else
                    {
                        Rooms.Add(new Room(roomNumber, basePrice));
                    }
                }
            }
        }

    }
}
