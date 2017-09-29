using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Spel
{
    public class Room
    {
        public string Description;
        private string Name;
        private bool firstTime = true;
        public List<Föremål> roomdecorations  = new List<Föremål>(); // saker man kan titta på.
        public List<Item> roomInventory = new List<Item>(); //saker man kan plocka upp.


        //constructor
        public Room(string description, string name)
        {
            Description = description;
            Name = name;
            
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
                if (roomInventory.Count >0 )
                {
                    Console.Write("There is a ");
                    foreach (var item in roomInventory)
                    {
                        Console.Write(item.GetName());
                       
                    }
                    Console.WriteLine(" in the " + Name + ".");
                }
                
                //firstTime = false;
            }
            else
            {   Console.Clear();
                Console.WriteLine("You are in the " + Name);
            }
        }
    }
}
