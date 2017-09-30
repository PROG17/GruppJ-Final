using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class Game
    {
        List<Room> RoomList = new List<Room>();
        private string user = "";
        private int roomNr = 0;
        private bool localGameRun = true;
        new Player player = new Player("");
        //constructor
        public Game(string name, Player playerSent)
        {
            user = name;
            player = playerSent;

            /*Rooms
            ============================================================================================================================================*/
            Room livingRoom = new Room("The living room is spacious with a large leather sofa in middle of the room. " +
                                       "\nIn front of the sofa is a coffee table with a fruit bowl and a magazine on. " +
                                       "\nIn front of the coffee table is a black flatscreen TV." +
                                       "\nAlong the right side is an antique drawer in dark wood with a lamp on. " +
                                       "\nThere are three possible exits from the Living Room. " +
                                       "\nOne door leads to what looks like an office. Next leads to the dining room. " +
                                       "\nThe third door has a sign that says \"Bathroom\" on it.", "Living room");

            Room office = new Room("The office is quite small but it houses one desk " +
                                   "\nwith one big drawer and a stationary computer. " +
                                   "\nThere are two small windows wich allows the moonlight to light up the room just " +
                                   "\nenough to make it possible to orientate without a lamp. " +
                                   "\nThe walls contains some motivational posters and a big picture in a black frame. " +
                                   "\nJust left of the entrance to the office is a big grey safe with a key lock. " +
                                   "\"Player\" may only enter the living room from the office", "Office");

            Room bathroom = new Room("This is a very small bathroom, espacially considered the size of the house. " +
                                     "\nThe bathroom just contains a small bathtub, a sink and a cabinet." +
                                     "\nThe floor and walls are all in tiles. The floor is a mix of black and white tiles, " +
                                     "\nlike a chessboard, and the walls are completely white. " +
                                     "\nThere is a small window close to the roof and the moonlight is shining straight " +
                                     "\nthrough the window allowing \"Player\" to see." +
                                     "\"Player\" may only enter the living room from the bathroom", "Bathroom");

            Room diningRoom1 = new Room(
                "The dining room is pretty dark since it is placed in the center of the house, only a little " + //Innan Bedroom är upplåst
                "\nmoonlight finds its way to this room so \"Player\" can only see the contours of" +
                "\n this rooms objects. There seems to be a large dining room tabel in the middle of the room " +
                "\nwith eight chairs around it. There appear to be some shelves in the corners of the room with " +
                "\ngreen plants on them. Not much interesting that \"Player\" can see in this room.\n" +
                "\nThere seem to be 4 possible exits from this room. To the kitchen, the livingroom, " +
                "\nthe cellar witch seems to be pitch black and then there is a closed door which " +
                "\nprobably lead to the bedroom.", "Dining Room");

            Room diningRoom2 = new Room(
                "The dining room is pretty dark since it is placed in the center of the house, only a little " + //Efter Bedroom är upplåst
                "\nmoonlight finds its way to this room so \"Player\" can only see the contours of" +
                "\n this rooms objects. There seems to be a large dining room tabel in the middle of the room " +
                "\nwith eight chairs around it. There appear to be some shelves in the corners of the room with " +
                "\ngreen plants on them. Not much interesting that \"Player\" can see in this room.\n" +
                "\nThere seem to be 4 possible exits from this room. To the kitchen, the livingroom, " +
                "\nthe cellar, witch seems to be pitch black, and the bedroom.", "Dining Room");

            Room kitchen = new Room(
                "The kitchen is huge! On the left side is a big freezer and an equally big fridge, seems like " +
                "\nthey are brand new. Centered in the kitchen is a lovely kitchen island with an integrated stove. " +
                "\nAll of the kitchen counters are made out of white marmor. All of the kitchen is dekorated with fresh " +
                "\nspices and herbs in little pots. Seems like the owner likes to spend time in the kitchen since he or she " +
                "\nseems to have put a lot of effort in dekorating the kitchen. From the kitchen window \"Player\" can " +
                "\nsee a fenced backyard. \"Player\" may  enter the diningroom or backyard through window from the kitchen.",
                "Kitchen"); //Window is Item here as well

            Room backyard = new Room("The backyard is huge. It has a perfectly cut lawn with an apple tree " +
                                     "\ngrowing in the left side of the backyard, seems to be Granny Smith but it's hard to tell from such a long distance. " +
                                     "\nStraight ahead you see a big barbecue grill. Alongside the house wall there is a flowerbed " +
                                     "\nwith some roses and tulips. The flowerbed is beautifully framed with some fist sized rocks." +
                                     "\nAfter a few moments \"Player\" can hear the sound of barking and spot a huge guard dog \nthat shows obvious signs of agression towards \"Player\", " +
                                     "\n\"Player\" must do something quickly!" +
                                     "\nThe gate to the front of the house is shut, probably locked." +
                                     "\nFrom the backyard \"player\" can see a window to the kitchen and a window to the bedroom, although it is closed. \n",
                "Backyard"); //Stone=Item

            Room bedroom = new Room("The bedroom pretty compact. There is not alot of spare room in here. " +
                                    "\nThe room is beautifully decorated with long curtains in dark, cozy colors. There is a tall " +
                                    "\nhuman sized mirror beside the bedroom drawer which reflect the moonlight, making it pretty easy do orientate in the bedroom." +
                                    "\nThere is a Queen sized bed with bedside tables at each side of the bed. " +
                                    "\nEach of the tables has a lamp, but only one of them has an alarmclock and a drawer." +
                                    "\n The owner must be living alone. " +
                                    "\n From inside the bedroom it is posible to unlock the door to the dining room. " +
                                    "\n\"Player\" can also see into the backyard through the window. ", "");

            Room darkCellar = new Room($"The cellar is pitch black and {user} can't see anything. " +
                                      $"\n {user} trips and fall down the stairs braking his neck.", "Cellar");

            Room lightCellar = new Room("The flashlight now reveals the cellar. " +
                                        "\nThe house owner obviously use this room as storage. There's loads of things down here. Mostly junk..." +
                                        "\nAlthough there is a well sorted wine cellar down here as well. " +
                                        "\n\"Player\" spot a bottle of Chateau Margaux, one of the worlds most expensive bottles of wine!" + /*Need corkskrew in kitchen :D (Item) */
                                        "\nFar back in the cellar is an old bookshelf with lots of junk in it and" +
                                        "\nin the middle of the cellar is a worned out pooltable. Seems to be mostly junk down here?",
                "");
            Room drawerLiRoom = new Room("You open the the drawer", "drawer");

            //Föremål
            //======================================================================================================================================================
            var sofa = new Föremål("Sofa", "A large sofa in black leather. Seats 4.");
            //var fruitBowl = new Föremål("Fruit Bowl", "A fruit bowl containing some fruit."); tar bort tillfälligt då den skapar problem pga namnet är två ord.
            var magazine = new Föremål("Magazine", "A home decorating magazine.");
            var drawerLR = new Föremål("Drawer",
                "A big antique drawer in dark wood. Could possibly be worth quite a lot of money.");
            var tv = new Föremål("TV", "A big Samsung flatscreen TV. Probably around 47 inches.");
            var lamp = new Föremål("Lamp",
                "This lamp seems familiar. Player think it's from IKEA and is called \"Böja\". " +
                "\n*Player makes a quick google-search*, Nope, it was from MIO.");
            var drawerOFFICE = new Föremål("Drawer", "A modern Office desk drawer.");
            var computer = new Föremål("Computer", "A computer... Nothing special. Moving on!");
            var windowOFFICE = new Föremål("Window",
                "The window can't be opened. Must get warm in here during the summer.");
            var picture = new Föremål("Picture",
                "A family photograph. Seems to be from a birthday party. Wonder if the house owner is on the picture...");
            var frame = new Föremål("Frame", "Just a picture frame. How interesting can it be..?!");
            var bathtub = new Föremål("Bathtub", "A classic bathtub in porcelain");
            var sink = new Föremål("Sink", "A modern, square-ish sink.");
            var cabinet = new Föremål("Cabinet", "A bathroom cabinet with a mirror.");
            var table = new Föremål("Table", "A large Dining Room table.");
            var plant = new Föremål("Plant", "Plants with green leaves. No flowers, just leaves.");
            var fridge = new Föremål("Fridge",
                "A big modern fridge in brushed steel. Oh! It has an ice maker! Fancy..!");
            var freezer = new Föremål("Freezer", "A big modern freezer in brushed steel.");
            var stove = new Föremål("Stove", "A thin induction hob on top of the kitchen counter.");
            var windowKITCHEN = new Föremål("Window", "A closed window with a view to the backyard.");
            var appletree = new Föremål("Apple Tree", "The apple tree is to far away to inspect and you " +
                                                      "\nprobably shouldn't head over there since the angry dog is here.");
            var grill = new Föremål("Grill",
                "A family sized gas grill. It's a Weber and looks like it could be used right now.");
            var roses = new Föremål("Roses", "beautiful red roses");
            var tulips = new Föremål("Tulips", "Tulips in various colors.");
            var windowBackyard = new Föremål("Window", "The window leads to the bedroom");
            var mirror = new Föremål("Mirror", "A big mirror. You see yourself");
            var drawerBEDROOM = new Föremål("Bedroom Drawer", "A bedside table drawer. Looks like it can be opened.");
            var bookshelf = new Föremål("Bookshelf",
                "A white bookshelf with loads of junk in it. Mostly books but also " +
                "\na few decorative items. Player spots something shiny behind one of the books." +
                "\nLooks like a key.");
            var pooltable = new Föremål("Pooltable", "An old worn out pooltable. There are no balls or cues.");

            //Items
            //======================================================================================================================================================
            var flashlightWoBatteries = new Item("Flashlight", "It doesn't have any batteries.", "Batteries");
            var key = new Item("Key", "Its a key with the inscription 'safe' ", "Safe");
            var rock = new Item("Rock", "Its a very throwable rock. It fits perfectly in your hand.", "Window");


            //Init av prylar till rum
            //=========================================================================================================================================================
            livingRoom.roomdecorations.Add(sofa);
            livingRoom.roomdecorations.Add(tv);
            livingRoom.roomdecorations.Add(drawerLR);
            livingRoom.roomdecorations.Add(magazine);
            livingRoom.roomdecorations.Add(lamp);
            livingRoom.roomInventory.Add(flashlightWoBatteries);

            office.roomdecorations.Add(computer);
            office.roomdecorations.Add(windowOFFICE);
            office.roomdecorations.Add(drawerOFFICE);
            office.roomdecorations.Add(frame);
            office.roomdecorations.Add(picture);

            bathroom.roomdecorations.Add(bathtub);
            bathroom.roomdecorations.Add(sink);
            bathroom.roomdecorations.Add(cabinet);

            diningRoom1.roomdecorations.Add(table);
            diningRoom1.roomdecorations.Add(plant);

            kitchen.roomdecorations.Add(fridge);
            kitchen.roomdecorations.Add(freezer);
            kitchen.roomdecorations.Add(stove);
            kitchen.roomdecorations.Add(windowKITCHEN);

            backyard.roomdecorations.Add(tulips);
            backyard.roomdecorations.Add(roses);
            backyard.roomdecorations.Add(appletree);
            backyard.roomdecorations.Add(grill);
            backyard.roomdecorations.Add(windowBackyard);
            backyard.roomInventory.Add(rock);

            drawerLiRoom.roomInventory.Add(flashlightWoBatteries);
            //LÄGGER IN RUMMEN I LISTA
            //===============================================================================================================================================
            RoomList.Add(livingRoom);
            RoomList.Add(drawerLiRoom);
            RoomList.Add(office);
            RoomList.Add(bathroom);
            RoomList.Add(diningRoom1);
            RoomList.Add(darkCellar);
            RoomList.Add(kitchen);
            RoomList.Add(backyard);
            RoomList.Add(bedroom);


        }

        //metoder.
        public void Input()
        {
            Console.Write("Choice: ");
            string input = Console.ReadLine().ToUpper();
            input = input.Trim();
            var inputWords = input.Split(' ');

            if (inputWords[0] == "GO")
            {
                if (roomNr == 0)//vardagsrummet
                {
                    switch (inputWords[1])
                    {
                        case "DININGROOM":
                            roomNr = 4;
                            GameRun();
                            break;
                        case "OFFICE":
                            roomNr = 2;
                            GameRun();
                            break;
                        case "BATHROOM":
                            roomNr = 3;
                            GameRun();
                            break;
                        default:
                            Console.WriteLine("No such room to enter from here.");
                            Console.Read();
                            GameRun();
                            break;
                    }
                }
                else if (roomNr == 2 || roomNr == 3 )//bad och office
                {
                    switch (inputWords[1])
                    {
                        case "BACK":
                            roomNr = 0;
                            GameRun();
                            break;
                        case "LIVINGROOM":
                            roomNr = 0;
                            GameRun();
                            break;
                        default:
                            Console.WriteLine("No such room to enter from here.");
                            Console.ReadKey();
                            GameRun();
                            break;


                    }
                }
                else if (roomNr == 4)
                {
                    switch (inputWords[1])
                    {
                        case "CELLAR":
                            roomNr = 5;
                            fatalChoice();//dödligt val
                            break;
                        case "KITCHEN":
                            roomNr = 6;
                            GameRun();
                            break;
                        case "BACK":
                            roomNr = 0;
                            GameRun();
                            break;
                        case "LIVINGROOM":
                            roomNr = 0;
                            GameRun();
                            break;
                        default:
                            Console.WriteLine("No such room to enter from here.");
                            Console.Read();
                            GameRun();
                            break;
                    }
                }
                else if (roomNr == 6)
                {
                    switch (inputWords[1])
                    {
                        case "BACK":
                            roomNr = 4;
                            GameRun();
                            break;
                        case "LIVINGROOM":
                            roomNr = 4;
                            GameRun();
                            break;
                        case "BACKYARD":
                            roomNr = 7;
                            GameRun();
                            break;
                        default:
                            Console.WriteLine("No such room to enter from here");
                            Console.Read();
                            GameRun();
                            break;
                    }
                }

            }
            else if (inputWords[0] == "LOOK")
            {
                bool itemFound = false;
                if (inputWords.Length == 1)//Om man bara skrivit look
                {
                    RoomList[roomNr].firstTime = true;
                    GameRun();
                }
                else 
                {
                    foreach (var item in RoomList[roomNr].roomdecorations)
                    {
                        string temp = item.GetName().ToUpper();
                        if (temp == inputWords[1])
                        {
                            itemFound = true;
                            item.PrintDescription();
                            Console.Read();
                            GameRun();
                        }
                    }
                    foreach (var item in player.playerInventory )
                    {
                        string temp = item.GetName().ToUpper();
                        if (temp == inputWords[1])
                        {
                            itemFound = true;
                            item.GetDescription();
                            Console.Read();
                            GameRun();
                        }
                    }
                    if (!itemFound)
                    {
                        Console.WriteLine("No " + inputWords[1].ToLower() + " to look at.");
                        Console.Read();
                        GameRun();
                    }
                }

            }
            else if (inputWords[0] == "GET")
            {
                string send = "";
                bool itemFound = false;
                foreach (var item in RoomList[roomNr].roomInventory)
                {
                    string temp = item.GetName().ToUpper();
                    if (temp == inputWords[1])
                    {
                        player.playerInventory.Add(item);
                        RoomList[roomNr].roomInventory.Remove(item);
                        itemFound = true;
                        Console.WriteLine("You picked up " + item.GetName() + ".");
                        Console.Read();
                        break;

                    }
                }

                if (!itemFound)
                {
                    Console.WriteLine("No " + inputWords[1].ToLower() + " to get.");
                    Console.Read();
                }

                

            }
            





        }

        public void fatalChoice()
        {
            localGameRun = false;
            Console.Clear();
            RoomList[roomNr].getDescription();
            GameRun();

        }

        public bool GameRun() //spelet startas
        {
            if (localGameRun)
            {
                RoomList[roomNr].roomEnter();
                Input();
                return true;

            }

            else
            {
                return false;
            }

        }
        
        
    }
}
