using System;
using System.CodeDom.Compiler;
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
        public static int Made(string choice, int rum, Room actual, Player user)
        {
            choice = choice.ToUpper();
            choice = choice.Trim();
            var choiceSplit = choice.Split(' ');
            //single word choices
            if (choice == "INVENTORY")
            {
                foreach (var item in user.playerInventory)
                {
                    Console.Clear();
                    Console.WriteLine("Your inventory: \n" + item.GetName());
                    Console.ReadKey();

                }
            }
            if (choice == "LOOK" && choiceSplit.Length == 1)
            {
                actual.getDescription();
                Console.WriteLine("Press enter to continue.");
                Console.Read();

            }//Om man bara skriver look för att se sig om i rummet
            //multiple word choices
            if (choiceSplit[0] == "INSPECT" && choiceSplit.Length > 1)// om man tittar på en pryl.
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
            if (choiceSplit[0] == "GET")
            {
                Console.WriteLine(choiceSplit[1]);
                Console.ReadLine();
                bool found = false;
                foreach (var item in actual.roomInventory)//plocka upp saker
                {
                    var temp = item.GetName().ToUpper();
                    if (choiceSplit[1] == temp)
                    {
                        user.PlayerInventoryAdd(item);
                        actual.roomInventory.Remove(item);
                        Console.WriteLine("you picked up " + item.GetName() + ".");
                        Console.Read();
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("No such item.");
                    Console.Read();
                }
            }
            if (choiceSplit[0] == "DROP")
            {
                Console.WriteLine(choiceSplit[1]);
                Console.ReadLine();
                bool found = false;
                foreach (var item in user.playerInventory) //droppa saker
                {
                    var temp = item.GetName().ToUpper();
                    if (choiceSplit[1] == temp)
                    {
                        user.playerInventory.Remove(item);
                        actual.roomInventory.Add(item);
                        Console.WriteLine("you droped " + item.GetName() + ".");
                        Console.Read();
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("No such item.");
                    Console.Read();
                }
            }
            if (choiceSplit[0] == "USE")
            {
                if (rum == 0)
                {
                    switch (choiceSplit[1])
                    {
                        case "DRAWER":
                            rum = 15;
                            break;

                        default:
                            Console.WriteLine("No such item.");
                            break;
                    }
                }

            }

            
            //movement choices.
            //livingroom
            if (rum == 0)
            {
                if (choiceSplit[0] == "ENTER")
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
                if (choiceSplit[0] == "ENTER")
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
                if (choiceSplit[0] == "ENTER")
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
                if (choiceSplit[0] == "ENTER")
                {
                    switch (choiceSplit[1])
                    {
                        case "LIVINGROOM":
                            rum = 0;
                            break;
                        case "BACKYARD":
                            rum = 7;
                            break;
                        default:
                            Console.WriteLine("No such room to enter.");
                            break;
                    }
                }
            }

            else if (rum == 15)
            {

                if (choiceSplit[0] == "ENTER")
                {
                    if (choiceSplit[1] == "LIVINGROOM" || choiceSplit[1] == "BACK")
                    {
                        rum = 0;
                    }
                }
            }




            return rum;
        }
    }
}
