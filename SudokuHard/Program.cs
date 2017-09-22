using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuHard
{
    class Program
    {
        static void Main(string[] args)
        {
            string Medium = "037060000205000800006908000000600024001503600650009000000302700009000402000050360";
            string Evil = "000009000004030000001000348605007000010304050000200803592000600000070200000100000";

            var game = new Sudoku(Evil);
            game.Solve();
        }
    }
}
