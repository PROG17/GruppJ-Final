﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Spel
{
    class Program
    {

        static void Main(string[] args)
        {
            
            bool menu = true;
            string name = "";
            bool game = true;
            while (menu)
            {
                Console.Clear();
                Console.Write("Please enter your name : ");
                name = Console.ReadLine();
                Console.Clear();
                if (name == "")
                {
                    Console.WriteLine("Please enter a valid name.");
                    Console.ReadKey();

                }
                else
                {
                    Console.WriteLine("Welcome " + name + ".\n");
                    menu = false;
                }

            }
            Console.WriteLine("\nCommands: " +
                              "\nEnter (Room), " +
                              "\nIn rooms where you may only go back you can write GO BACK,  " +
                              "\nUSE,  " +
                              "\nUSE item ON item, " +
                              "\nLOOK. " +
                              "\nINSPECT (Object)" +
                              "\nINVENTORY to show your inventory" +
                              "\n\nFor Controls, write HELP" +
                              "\nPress enter to start game.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You are a masterthief who just broke in to a big house." +
                        "\nTo keep the alarm from going off you had to cut the power.");
            string choice = "LOOK";
            Player user = new Player(name);

            Console.ReadLine();
            var play = new Game(name, user);

            while (game)
            {
                game = play.GameRun();
            }
            Console.WriteLine("thanks for paly!");

            










            //=============================================================================================================================================================

            //            var choice = "";
            //            bool game = true;
            //            //game
            //            while (game)
            //            {
            //                if (roomNr == 0) //livingroom
            //                {
            //                    livingRoom.roomEnter();
            //                    Console.Write("Choice: ");
            //                    choice = Console.ReadLine();
            //                    roomNr = Choice.Made(choice, roomNr, livingRoom,user);

            //                }
            //                if (roomNr == 1)//office
            //                {
            //                    office.roomEnter();
            //                    Console.Write("Choice: ");
            //                    choice = Console.ReadLine();
            //                    roomNr = Choice.Made(choice, roomNr, office, user);
            //                }
            //                if (roomNr == 2)//bathroom
            //                {
            //                    bathroom.roomEnter();
            //                    Console.Write("Choice: ");
            //                    choice = Console.ReadLine();
            //                    roomNr = Choice.Made(choice, roomNr, bathroom,user);
            //                }
            //                if (roomNr == 4)//diningroom
            //                {
            //                    diningRoom1.roomEnter();
            //                    Console.Write("Choice: ");
            //                    choice = Console.ReadLine();
            //                    roomNr = Choice.Made(choice, roomNr, diningRoom1,user);
            //                }
            //                if (roomNr == 6)//KITCHEN
            //                {
            //                    kitchen.roomEnter();
            //                    Console.Write("Choice: ");
            //                    choice = Console.ReadLine();
            //                    roomNr = Choice.Made(choice, roomNr, kitchen,user);
            //                }
            //                if (roomNr == 7)//backyard
            //                {
            //                    backyard.roomEnter();
            //                    Console.Write("Choice: ");
            //                    choice = Console.ReadLine();
            //                    roomNr = Choice.Made(choice, roomNr, backyard,user);

            //                }
            //                if (roomNr == 15)//livingroom drawer
            //                {
            //                    drawerLiRoom.roomEnter();
            //                    Console.Write("Choice: ");
            //                    choice = Console.ReadLine();
            //                    roomNr = Choice.Made(choice, roomNr, drawerLiRoom, user);

            //                }

            //                //Death in cellar.
            //                if (roomNr == 20)
            //                {
            //                    Console.Clear();
            //                    Console.WriteLine(@"You fell down the stairs and broke your neck. 
            //You are so dead. 
            //But since you are the bad guy in this story that's kinda OK...");
            //                    Console.WriteLine(@"  ____   ____  ___ ___    ___       ___   __ __    ___  ____  
            // /    | /    ||   |   |  /  _]     /   \ |  |  |  /  _]|    \ 
            //|   __||  o  || _   _ | /  [_     |     ||  |  | /  [_ |  D  )
            //|  |  ||     ||  \_/  ||    _]    |  O  ||  |  ||    _]|    / 
            //|  |_ ||  _  ||   |   ||   [_     |     ||  :  ||   [_ |    \ 
            //|     ||  |  ||   |   ||     |    |     | \   / |     ||  .  \
            //|___,_||__|__||___|___||_____|     \___/   \_/  |_____||__|\_|
            //                                                              ");
            //                    Console.Read();
            //                    game = false;
            //                }


            //            }


        }
    }
}
