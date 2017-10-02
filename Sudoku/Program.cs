using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            string Easy = "003020600900305001001806400008102900700000008006708200002609500800203009005010300";
            string Medium = "037060000205000800006908000000600024001503600650009000000302700009000402000050360";
            string Evil = "000009000004030000001000348605007000010304050000200803592000600000070200000100000";
            string nogo = "000099000004030000001000348605007000010304050000200803592000600000070200000100000";

            string test1 = "305420810487901506029056374850793041613208957074065280241309065508670192096512408"; //Naked Singles
            string test2 = "002030008000008000031020000060050270010000050204060031000080605000000013005310400"; //Hidden Singles
            string test3 = "090300001000080046000000800405060030003275600060010904001000000580020000200007060"; //No solution
            bool alla = false;
            while (true)
            {

                Console.WriteLine("Vill du lösa ALLA pussel eller endast ENKLA?");
                string svar = Console.ReadLine().ToUpper();
                if (svar == "ALLA")
                {
                    alla = true;
                    break;
                }
                else if (svar == "ENKLA")
                {
                    alla = false;
                    break;
                }
                else
                    Console.Clear();
                Console.WriteLine("Felaktigt svar. försök igen.");

            }
            var game = new Sudoku(test3);
            game.Solve(alla);
            Console.ReadKey();

        }
    }
}
