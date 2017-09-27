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

        public void GetRoomDescription()//När någon använder look. 
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

        public void RoomEntered()// i princip samma sak fast här kan vi lägga till en if- för att se om det är första gången i rummet. Då kan det förenklat stå "you are back in the kitchen".
        {

            Console.WriteLine("You are in the " + name);
            Console.WriteLine(description);
            Console.Write("you can:");
            foreach (var choice in avaliblechoices)//skriver ut hållen man kan gå åt som vi initialiserar i program.cs (på detta sätt kan man bygga ett helt nytt spel på vårat skelett om man vill)
            {
                Console.Write(choice);

            }

            Console.Write(" Or interact with: ");//skriver ut vilka prylar som finns i rummet.
            foreach (var item in RoomInventory)
            {

                item.PrintName();
                Console.Write(" ");

            }

        }

    }

}
