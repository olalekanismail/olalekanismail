using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject
{
    public class Rooms
    {

        public int RoomPrice { get; set; }
        public string RoomStandard { set; get; }
        public static string RoomID { set; get; }
        public bool IsAvailable { get; set; } 
        public string  RoomNumber { get; set; }
        public  int number = 0;
        
        public static List<Rooms> room = new List<Rooms>();

        public Rooms(int roomPrice,string standardRoom)
        {
            RoomPrice = roomPrice;
            RoomStandard = standardRoom;
            RoomNumber = GenerateRoomNumber();
            number++;
            IsAvailable = true;
        }
        private string GenerateRoomNumber()
        {
            return $"{number + 1.ToString("01")}";
        }
        public static void UpDateRoomAvailability(string roomNum, bool status)
        {
            foreach (var rom in room)
            {
                if (rom.RoomNumber.Equals(roomNum))
                {
                   
                    rom.IsAvailable = status;
                    Console.WriteLine("The room is not Available");
                }
            }
        }
        
        public static void AvailableRooms()
        {
            for (int j = 0; j < room.Count; j++)
            {
                if (room[j].IsAvailable)
                {
                    
                    Console.WriteLine($"{j + 1}.{room[j].RoomNumber}.{room[j].RoomStandard}...{room[j].RoomPrice}");
                }
            }
        }
       
    }
}
