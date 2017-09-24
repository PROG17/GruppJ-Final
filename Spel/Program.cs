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
            var gustav = new Player("Gustav");//tillfälligt namn. ska bytas ut mot vad användaren anger.

            //inits of items Här skapas items. Det är bara att lägga till items här. 
            var key = new Item("Key", "A rusty old key");
            var flashlight = new Item("Flashlight", "A flashligt. I´t doesn't have any batteries.");

            //inits of rooms Här skapas rummen. Dom får de items dom ska ha i sin inventory och möjliga valen som inte används förutom att dom skrivs ut 
            
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

            //Rooms added to list. Här hamnar rummen i en lista för att kunna utdelas och intrageras med genom en variabel (roomNr)
            List<Room> roomList = new List<Room>();
            roomList.Add(room0);
            roomList.Add(room1);
            roomList.Add(room2);

            //spelet körs
            while (game)
            {
                bool breakit = false;//används ej för tillfället
                input = "";
                Console.Clear();
                roomList[roomNr].RoomEntered(); //rummet vi är kör sin egen beskrivning roomlist är listan [roomNr] är rummets plats i listan och roomentered är en metod i klassen.
                Console.WriteLine();
                input = Console.ReadLine().ToUpper();//här formateras inputten och delas in i två delar. Detta tror jag vi får köra genom en metod. 

                inputType = input.Substring(0, input.IndexOf(" "));
                inputAction = input.Substring(input.IndexOf(" "));
                inputType = inputType.Trim();
                inputAction = inputAction.Trim(); //vi får ut tre strängar, Antingen hela inputen eller inputen delad i två. Problemet uppstår om det inte finns ett mellanslag. Då får vi error.
                //vi löser det i en metod.

                //Console.Write(inputType);
                //Console.Write(inputAction);
                if (input == "MY INVENTORY")//man kan alltid kolla sin inventory.
                {
                    Console.Write("Your Items: ");
                    foreach (var item in gustav.playerInventory)
                    {
                        item.PrintName();
                        Console.Write(" - ");
                        item.GetDescription();

                    }
                    int inven = 3 - gustav.playerInventory.Count; //Skriver ut hur mycket plats du har kvar av dina tre platser.
                    Console.WriteLine("You have " + inven + " inventory slots left");
                    input = Console.ReadLine();
                }
                if (inputType == "TAKE")//plocka upp saker. Den här är ganska jobbig kodmässigt. 
                {
                    for (int i = 0; i < roomList[roomNr].RoomInventory.Count; i++)//sök igenom rummets inventory. Så lång som listan av inventorys är så länge ska du söka efter det ordet vi försöker plocka upp.
                    {
                        string temp = roomList[roomNr].RoomInventory[i].GetName().ToUpper();//Varje sak i roominventory kör sin getname. Finns det något som heter det vi försökte plocka upp? 
                        if (temp == inputAction)//om returnerat name är samma som det vi försökt plocka upp så ja!
                        {
                            gustav.playerInventory.Add(roomList[roomNr].RoomInventory[i]);//lägger till saken i players inventory
                            roomList[roomNr].RoomInventory.RemoveAt(i);//tar bort saken ur rummets inventory
                            Console.WriteLine("you picked up the " + temp + ".");
                            break;
                        }
                    }

                    Console.Write("there is no " + inputAction.ToLower() + " in the room.");//Om nej! skrivs detta ut. Dock skrivs det även ut om vi plockar upp för jag har inte kommit på ett smidigt sätt att hoppa ur loopen.
                    Console.WriteLine();
                    input = Console.ReadLine();
                }
                if (inputType == "DROP")// här är samma som ovan fast omvänd. Vi droppar, Om saken finns lämnar den player inventory och hamnar i rummet vi är i.
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

                //Dom sakerna och händelserna som är unika för rummet sköts nedan.
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
                                Console.WriteLine("Not a valid move.");
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
