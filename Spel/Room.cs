using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class Room
    {
        public string Description;
        private string Name;
        private bool firstTime = true;
        public Room(string description, string name)
        {
            Description = description;
            Name = name;
        }

        public void getDescription()
        {
            Console.WriteLine(Description);
        }

        public void roomEnter()
        {
            if (firstTime)
            {
                Console.WriteLine(Description);
                firstTime = false;
            }
            else
            {
                Console.WriteLine("You are back in the " + Name);
            }
        }
    }
}
