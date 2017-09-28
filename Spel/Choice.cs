using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class Choice
    {
        public static int Made(string choice, int rum, Room actual)
        {
            choice = choice.ToUpper();
            var choiceSplit = choice.Split(' ');

            if (choice == "LOOK")// Om man bara skriver look..
            {
                actual.getDescription();
                Console.WriteLine("Press enter to continue.");
                Console.Read();
                
            }
            if (choiceSplit[0] == "LOOK" && choiceSplit.Length > 1)// om man tittar på en pryl.
            {
                foreach (var item in actual.roomInventory)
                {
                    if (choiceSplit[1] == item.GetName() || choiceSplit[2] == item.GetName())
                    {
                        
                    }
                }
            }

            //livingroom
            if (rum == 0 )
            {
                if (choiceSplit[0] == "GO")
                {
                    switch (choiceSplit[1])
                    {
                        case "KITCHEN":
                            rum = 4;
                            break;
                        case "BATHROOM":
                            rum = 2;
                            break;
                        case "OFFICE":
                            rum = 1;
                            break;
                        default:
                            Console.WriteLine("No such room to enter. \n Press enter to continue.");
                            Console.Read();
                            break;
                    }
                }
            }
            //office
            if (rum == 1)
            {
                if (choiceSplit[0] == "GO" && choiceSplit[1] == "BACK" )
                {
                    rum = 0;
                }
                
            }


        
            return rum;
        }
    }
}
