using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    public class Item
    {

        //instansvariabler 
        private string name = "";
        private readonly string description = "";
        private string usables = "";

        //constructor
        public Item(string _name, string _dscrpt, string usable)
        {
            name = _name;
            description = _dscrpt;
            usables = usable;
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

        public bool Usable(string itemSent)
        {
            if (itemSent == usables)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
