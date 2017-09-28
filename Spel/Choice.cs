using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class Choice
    {
        public static int Made(string choice, int rum, Room actual)
        {
            choice = choice.ToUpper();
            choice = choice.Trim();
            var choiceSplit = choice.Split(' ');
            
            if (choice == "LOOK" && choiceSplit.Length == 1)
            {
                actual.getDescription();
                Console.WriteLine("Press enter to continue.");
                Console.Read();
                
            }//Om man bara skriver look för att se sig om i rummet
            if (choiceSplit[0] == "LOOK" && choiceSplit.Length > 1)// om man tittar på en pryl.
            {
                bool found = false;
                foreach (var item in actual.roomdecorations)// kollar om saken man försöker titta på finns i rummet 
                {
                    if (choiceSplit[1] == item.GetName().ToUpper() || choiceSplit[2] == item.GetName().ToUpper())
                    {
                        item.PrintDescription();
                        Console.ReadLine();
                        found = true;
                        break;
                    }
                    
                    

                }
                if (!found)
                {
                    Console.WriteLine("No such thing in room");
                    Console.Read();

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
            if (rum == 1 || rum == 2) //både badrum och office leder bara tillbaka.
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
