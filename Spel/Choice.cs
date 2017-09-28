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
                    if (choiceSplit[1] == item.GetName().ToUpper())
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
            if (rum == 0)
            {
                if (choiceSplit[0] == "GO")
                {
                    switch (choiceSplit[1])
                    {
                        case "DININGROOM":
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
            //office and bathroom
            else if (rum == 1 || rum == 2) //både badrum och office leder bara tillbaka.
            {
                if (choiceSplit[0] == "GO")
                {
                    if (choiceSplit[1] == "LIVINGROOM" || choiceSplit[1] == "BACK")
                    {
                        rum = 0;
                    }
                }

            }
            //Diningroom
            else if (rum == 4)
            {
                if (choiceSplit[0] == "GO")
                {
                    if (choiceSplit[1] == "LIVINGROOM")
                    {
                        rum = 0;
                    }
                    else if (choiceSplit[1] == "BEDROOM")
                    {
                        Console.WriteLine("The door is locked.");
                        Console.Read();
                    }
                    else if (choiceSplit[1] == "CELLAR")
                    {
                        Console.WriteLine("It is really dark. Are you sure you want to go down to the cellar? (YES/NO)");
                        string lethalChoice = Console.ReadLine().ToUpper();
                        bool choicemade = false;
                        while (!choicemade)
                        {
                            switch (lethalChoice)
                            {
                                case "YES":
                                    rum = 20;
                                    choicemade = true;
                                    break;
                                case "NO":
                                    choicemade = true;
                                    break;
                                default:
                                    Console.WriteLine("Unvalid choice. please answer yes or no");
                                    lethalChoice = Console.ReadLine().ToUpper();
                                    break;
                            }
                        }

                    }
                    else if (choiceSplit[1] == "KITCHEN")
                    {
                        rum = 6;
                    }
                }
            }
            else if (rum == 6)
            {
                if (choiceSplit[0] == "GO")
                {
                    
                }
            }




            return rum;
        }
    }
}
