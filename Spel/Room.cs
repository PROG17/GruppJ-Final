using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class Room
    {

        private string name = "";
        private string description = "";
        private bool firstVisist = true;
        public List<Item> RoomInventory = new List<Item>();//Saker i rummet
        public List<string> avaliblechoices = new List<string>();

        public Room(string _name, string _dscrtp)
        {
            name = _name;
            description = _dscrtp;
        }

        public void GetRoomDescription()
        {
            Console.WriteLine(description);
            Console.Write("you can:");
            foreach (var choice in avaliblechoices)
            {
                Console.Write(choice);

            }
            foreach (var item in RoomInventory)
            {
                item.PrintName();
            }
        }

        public void RoomEntered()
        {

            Console.WriteLine("You are in the " + name);
            Console.WriteLine(description);
            Console.Write("you can:");
            foreach (var choice in avaliblechoices)
            {
                Console.Write(choice);

            }

            Console.Write(" Or interact with: ");
            foreach (var item in RoomInventory)
            {

                item.PrintName();
                Console.Write(" ");

            }
        }
    }
}
