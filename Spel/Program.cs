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
            Intro.PlayIntro();

            Room livingRoom = new Room("You are in the living room.\n " +
                "The living room is spacious with a large leather sofa in middle of the room. " +
                "In front of the sofa is a coffee table with a fruit bowl and a magazine on. In front of the coffee table is a black flatscreen TV." +
                "Along the right side is an antique drawer in dark wood with a lamp on. " +
                "There are three possible exits from the Living Room. One door leads to what looks like an office. Next leads to the " +
                "dining room. The third door, which is closed, has a sign as it says \"Bathroom\" on.", "Living room");

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

            Room diningRoom = new Room("You are in the dining room\n" +
                "The dining room is pretty dark since it is placed in the center of the house, only a little moonlight finds its way to this room so \"Player\" " +
                "can only see the contours of this rooms objects. There seems to be a large dining room tabel in the middle of the room with eight chairs around it. " +
                "There appear to be some shelves in the corners of the room with green plants on them. Not much interesting that \"Player\" can see in this room." +
                "There seem to be 4 possible exits from this room. To the kitchen, the livingroom, the cellar witch seems to be pitch black since it's underground " +
                "and then there is a closed door which probably lead to the bedroom.","Dining Room");

            
        }
    }
}
