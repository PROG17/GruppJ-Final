using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    public class Föremål
    {
        public string Description;
        public string Name;

        public Föremål(string name, string description)
        {
            Description = description;
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        public void PrintDescription()
        {
            Console.WriteLine(Description);
            
        }

        
    }
}
