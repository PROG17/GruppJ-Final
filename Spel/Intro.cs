using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    static class Intro
    {
        static public void PlayIntro()
        {
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine(@" 
 ___ ___   ____  _____ ______    ___  ____  ______  __ __  ____    ___  _____ 
|   |   | /    |/ ___/|      |  /  _]|    \|      ||  |  ||    |  /  _]|     |
| _   _ ||  o  (   \_ |      | /  [_ |  D  )      ||  |  | |  |  /  [_ |   __|
|  \_/  ||     |\__  ||_|  |_||    _]|    /|_|  |_||  _  | |  | |    _]|  |_  
|   |   ||  _  |/  \ |  |  |  |   [_ |    \  |  |  |  |  | |  | |   [_ |   _] 
|   |   ||  |  |\    |  |  |  |     ||  .  \ |  |  |  |  | |  | |     ||  |   
|___|___||__|__| \___|  |__|  |_____||__|\_| |__|  |__|__||____||_____||__|   
                                                                              ");
                Console.WriteLine("\t\t\tA game by Jocke and Gustav");
                Console.Beep(440, 150);
                Console.Beep(840, 150);
                Console.Beep(440, 150);
                Console.Beep(840, 150);
                Console.Beep(440, 150);
                Console.Beep(400, 150);
                Console.Beep(600, 150);
                Console.Beep(660, 150);
                
                

            }
        }
    }

}
