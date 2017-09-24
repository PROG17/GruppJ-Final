using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class Item
    {

        //instansvariabler 
        private string name = "";
        private readonly string description = "";

        //constructor
        public Item(string _name, string _dscrpt)
        {
            name = _name;
            description = _dscrpt;
        }

        public void GetDescription()
        {
            Console.WriteLine(description);
        }

        public void PrintName()
        {
            Console.Write(name);
        }
        public string GetName()
        {
            return name;
        }
    }
}
