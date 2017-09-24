using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    public class Room
    {
        public string Description;
        private string Name;
        private bool firstTime = true;
        private int roomNr;

        //constructor
        public Room(string description, string name, int roomnr)
        {
            Description = description;
            Name = name;
            this.roomNr = roomnr;
        }

        public void getDescription()
        {
            Console.Clear();
            Console.WriteLine(Description);
        }

        public void roomEnter()
        {
            if (firstTime)
            {
                Console.Clear();
                Console.WriteLine(Description);
                firstTime = false;
            }
            else
            {   Console.Clear();
                Console.WriteLine("You are back in the " + Name);
            }
        }
    }
}
