using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class Item
    {
        private string name = "";
        private string description = "";

        public Item(string _name, string _description)
        {
            name = _name;
            description = _description;
        }

        public void GetDescription()
        {
            Console.WriteLine(description);
        }

    }
}
