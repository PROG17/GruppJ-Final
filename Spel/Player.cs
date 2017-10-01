using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    public class Player
    {
        public string name = "";
        public List<Item> playerInventory = new List<Item>();

        public Player(string name)
        {
            this.name = name;
        }

        public void PlayerInventoryAdd(Item item)
        {
            playerInventory.Add(item);
        }
    }
}
