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
        public List<Item> playerInventory = new List<Item>();

        public Player(string name)
        {
            this.name = name;
        }
    }
}
