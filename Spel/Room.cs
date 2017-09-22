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

        public Room(string description, string name)
        {
            Description = description;
            Name = name;
        }
    }
}
