using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class Program
    {
        static void Main(string[] args)
        {

            int roomNr = 0;
            bool game = true;
            string input = "";
            string inputType = "";
            string inputAction = "";

            //init of player 
            var gustav = new Player("Gustav");

            //inits of items
            var key = new Item("Key", "A rusty old key");
            var flashlight = new Item("Flashlight", "A flashligt. I´t doesn't have any batteries.");

            //inits of rooms
            var room0 = new Room("Livingroom", "\nYou can see three doors: West door says 'office'. North door says 'DinnerRoom' East door says 'Bathroom'");
            room0.RoomInventory.Add(flashlight);
            room0.avaliblechoices.Add(" Go North");
            room0.avaliblechoices.Add(" Go East");
            room0.avaliblechoices.Add(" Go West");

            var room1 = new Room("Office", "You are standing in an office. ");
            room1.avaliblechoices.Add(" Go Back");
            room1.RoomInventory.Add(key);
            var room2 = new Room("Bathroom", "You are standing in a bathroom. ");
            room2.avaliblechoices.Add(" Go Back");

            //Rooms added to list
            List<Room> roomList = new List<Room>();
            roomList.Add(room0);
            roomList.Add(room1);
            roomList.Add(room2);


            while (game)
            {
                bool breakit = false;
                input = "";
                Console.Clear();
                roomList[roomNr].RoomEntered();
                Console.WriteLine();
                input = Console.ReadLine().ToUpper();

                inputType = input.Substring(0, input.IndexOf(" "));
                inputAction = input.Substring(input.IndexOf(" "));
                inputType = inputType.Trim();
                inputAction = inputAction.Trim();

                //Console.Write(inputType);
                //Console.Write(inputAction);
                if (input == "MY INVENTORY")
                {
                    Console.Write("Your Items: ");
                    foreach (var item in gustav.playerInventory)
                    {
                        item.PrintName();
                        Console.Write(" - ");
                        item.GetDescription();

                    }
                    int inven = 3 - gustav.playerInventory.Count;
                    Console.WriteLine("You have " + inven + " inventory slots left");
                    input = Console.ReadLine();
                }
                if (inputType == "TAKE")
                {
                    for (int i = 0; i < roomList[roomNr].RoomInventory.Count; i++)//sök igenom rummets inventory
                    {
                        string temp = roomList[roomNr].RoomInventory[i].GetName().ToUpper();//Varje sak i roominventory kör sin getname 
                        if (temp == inputAction)//om returnerat name är samma som det vi försökt plocka upp sp
                        {
                            gustav.playerInventory.Add(roomList[roomNr].RoomInventory[i]);//lägger till i players inventory
                            roomList[roomNr].RoomInventory.RemoveAt(i);//tar bort ur rummets inventory
                            Console.WriteLine("you picked up the " + temp + ".");
                            break;
                        }
                    }

                    Console.Write("there is no " + inputAction.ToLower() + " in the room.");
                    Console.WriteLine();
                    input = Console.ReadLine();
                }
                if (inputType == "DROP")
                {

                    for (int i = 0; i < gustav.playerInventory.Count; i++)//sök igenom rummets inventory
                    {
                        string temp = gustav.playerInventory[i].GetName().ToUpper();//Varje sak i roominventory kör sin getname 

                        if (temp == inputAction)//om returnerat name är samma som det vi försökt droppa 
                        {
                            roomList[roomNr].RoomInventory.Add(gustav.playerInventory[i]);
                            gustav.playerInventory.RemoveAt(i);
                            Console.WriteLine("you dropped the " + temp + ".");
                            Console.ReadLine();
                            break;
                        }
                    }
                    Console.Write("there is no " + inputAction.ToLower() + " in your inventory.");
                    Console.WriteLine();
                    input = Console.ReadLine();
                }

                if (roomNr == 0)//Vardagsrummet
                {

                    if (inputType == "GO")
                    {
                        switch (inputAction)
                        {
                            case "EAST":
                                roomNr = 1;
                                input = "";
                                break;
                            case "NORTH":
                                roomNr = 4;
                                break;
                            case "WEST":
                                roomNr = 2;
                                break;
                            default:
                                Console.WriteLine("Not a valid motve.");
                                input = Console.ReadLine();
                                break;
                        }
                    }

                }

                else if (roomNr == 1)
                {
                    if (inputType == "GO")
                    {
                        switch (inputAction)
                        {
                            case "BACK":
                                roomNr = 1;
                                break;
                            default:
                                Console.WriteLine("Not a valid move.");
                                input = Console.ReadLine();
                                break;
                        }
                    }

                }

            }
        }
    }
}
