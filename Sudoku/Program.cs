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
            var game = new Sudoku(Evil);
            game.Solve();
            Console.ReadKey();
            
        }
    }
}
