using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class Player
    {
        private string name = "";
        public List<Item> PlayerInventory = new List<Item>();

        public Player(string _name)
        {
            name = _name;
        }
    }
}
