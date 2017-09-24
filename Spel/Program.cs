using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spel
{
    class Program
    {
        static void Main(string[] args)
        {
            Intro.PlayIntro();
            while (true)
            {
                Room livingRoom = new Room("You are in the living room.\n " +
                "The living room is spacious with a large leather sofa in middle of the room. " +
                "In front of the sofa is a coffee table with a fruit bowl and a magazine on. In front of the coffee table is a black flatscreen TV." +
                "Along the right side is an antique drawer in dark wood with a lamp on. " +
                "There are three possible exits from the Living Room. One door leads to what looks like an office. Next leads to the " +
                "dining room. The third door, which is closed, has a sign that says \"Bathroom\" on it.", "Living room");

                Room office = new Room("You are in the office.\n" +
                    "The office is quite small but it houses one desk with one big drawer and a stationary computer. There are two small windows wich allows the moonlight to " +
                    "light up the room enough to make it possible to orientate without a lamp. The walls contains some motivational posters " +
                    "and a big picture in a black frame. \nJust left of the entrance to the office is a big grey safe with a key lock. " +
                    "\"Player\" may only enter the living room from the office", "Office");

                Room bathroom = new Room("You are in the bathroom\n" +
                    "This is a very small bathroom, espacially considered the size of the house. The bathroom just contains a small bathtub, a sink and a cabinet." +
                    "The floor and walls are all in tiles. The floor is a mix of black and white tiles, like a chessboard, and the walls are completely white. " +
                    "There is a small window close to the roof and the moonlight is shining straight through the window allowing \"Player\" to see." +
                    "\"Player\" may only enter the living room from the bathroom", "Bathroom");

                Room diningRoom1 = new Room("You are in the dining room\n" +   //Innan Bedroom är upplåst
                    "The dining room is pretty dark since it is placed in the center of the house, only a little moonlight finds its way to this room so \"Player\" " +
                    "can only see the contours of this rooms objects. There seems to be a large dining room tabel in the middle of the room with eight chairs around it. " +
                    "There appear to be some shelves in the corners of the room with green plants on them. Not much interesting that \"Player\" can see in this room.\n" +
                    "There seem to be 4 possible exits from this room. To the kitchen, the livingroom, the cellar witch seems to be pitch black " +
                    "and then there is a closed door which probably lead to the bedroom.", "Dining Room");

                Room diningRoom2 = new Room("You are in the dining room\n" +  //Efter Bedroom är upplåst
                    "The dining room is pretty dark since it is placed in the center of the house, only a little moonlight finds its way to this room so \"Player\" " +
                    "can only see the contours of the objects in this room. There seems to be a large dining room tabel in the middle of the room with eight chairs around it. " +
                    "There appear to be some shelves in the corners of the room with green plants on them. Not much interesting that \"Player\" can see in this room.\n" +
                    "There is 4 possible exits from this room. To the kitchen, the livingroom, the cellar witch seems to be pitch black since it's underground " +
                    "and the bedroom.", "Dining Room");

                Room kitchen = new Room("You are in the kitchen\n" +
                    "The kitchen is huge! On the left side is a big freezer and an equally big fridge, seems like they are brand new. Centered in the kitchen is a " +
                    "lovely kitchen island with an integrated stove. All of the kitchen counters are made out of white marmor. All of the kitchen is dekorated with fresh " +
                    "spices and herbs in little pots. Seems like the owner likes to spend time in the kitchen since the owner seems to have put a lot of effort in dekorating " +
                    "the kitchen. From the kitchen window \"Player\" can see the fenced backyard.\n" +
                    "\"Player\" may only enter the dining room from the kitchen.", "Kitchen");

                Room backyard = new Room("You are in the backyard\n" +
                    "The backyard is huge. It has a perfectly cut lawn with an apple tree " +
                    "\ngrowing in the left side of the backyard, seems to be Granny Smith but it's hard to tell from such a long distance. " +
                    "\nStraight ahead you see a barbecue grill and a picknick bench. Alongside the house wall there is a flowerbed " +
                    "\nwith some roses and tulips. The flowerbed is beautifully framed with some fist sized rocks." +
                    "\nAfter a few moments \"Player\" can hear the sound of barking and spot a huge guard dog \nthat shows obvious signs of agression towards \"Player\", " +
                    "\n\"Player\" must do something quickly!" +
                    "\nThe gate to the front of the house is locked." +
                    "\nFrom the backyard \"player\" can see a window to the kitchen and a window to the bedroom, although it is closed. \n", "Backyard");

                Room bedroom = new Room("You are in the Bedroom\n" +
                    "The bedroom pretty compact. There is not alot of spare space in here. " +
                    "\nThe room is beautifully decorated with long curtains in dark, cozy colors. There is a tall " +
                    "\nhuman sized mirror beside the bedroom drawer which reflect the moonlight, making it pretty easy do orientate in the bedroom." +
                    "\nThere is a Queen sized bed with bedside tables at each side of the bed. " +
                    "\nEach of the tables has a lamp, but only one of them has an alarmclock and a drawer. " +
                    "\n From inside the bedroom it is posible to unlock the door to the dining room. " +
                    "\n\"Player\" can also see into the backyard through the window. ", "");

                Room darkCellar = new Room("You are in the cellar\n" +
                    "The cellar is pitch black and \"Player\" can't see anything. " +
                    "\n\"Player\" trips and fall down the stairs hurting his ankle pretty bad. " +
                    "\nOh Shit! The ankle is broken! Moving around will take twice as long now." +
                    "\n\"Player\" can't see anything. Only available exit is back to dining room.", "Cellar");

                Room lightCellar = new Room("You are in the cellar\n" +
                    "The flashlight now reveals the cellar. " +
                    "\nThe house owner obviously use this room as storage. There's loads ofthings down here. Mostly junk..." +
                    "\nAlthough there is a well sorted wine cellar down here as well. " +
                    "\n\"Player\" spot a bottle of Chateau Margaux, one of the worlds most expensive bottles of wine!" +  /*Need corkskrew in kitchen :D */
                    "\nFar back in the cellar is an old bookshelf with lots of junk in it. Seems to only be junk down here?", ""); //Key in Cigarrbox in bookshelf
                                                                                                                                   //Probably need more stuff to search down here...



            }






        }
    }
}
