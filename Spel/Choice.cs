using System;
using System.Collections.Generic;
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
            if (rum == 1) // från vardagasrummet
            {
                switch (choice)
                {
                    case "GO NORTH": //matsal
                        rum = 4;
                        break;
                    case "GO WEST"://office
                        rum = 2;
                        break;
                    case "GO EAST"://toa
                        rum = 3;
                        break;

                    case "LOOK"://
                        actual.getDescription();
                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine();
                        Console.Write("Invalid Choice.");
                        break;
                }
            }
            return rum;
        }
    }
}
