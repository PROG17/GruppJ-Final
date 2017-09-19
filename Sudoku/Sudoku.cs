using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Sudoku
    {
       //fields 
        public int[,] board = new int [9, 9];
        public string number;
        public int index = 0;

        //constructor
        public Sudoku (string num)
        {
            number = num;
            CreateBoard();
        }

        //metoder
        public void CreateBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = (int) Char.GetNumericValue(number[index]);
                    index++;
                }
            }
            DisplayBoard();
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i,j]);
                    if (j == 2 || j == 5)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
                if (i == 2 || i == 5)
                {
                    Console.WriteLine("-----------");
                }
                
            }
        }
        public void Solve()
        {
            bool solved = false;
            int x = 0;
            while (solved == false)
            {
                solved = true;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (board[i, j] == 0)  //Om nuvarande cell innehåller värdet 0 så:
                        {
                            solved = false;
                            board[i,j] = Search(i, j); //Anropa metod som tilldelar cellen sitt logiskt möjliga värde

                        }
                    }
                }   
            }
            Console.WriteLine("\nSolved!\n");
            DisplayBoard();
        }
        public int Search(int row/*i*/, int col/*j*/)
        {
            int nyttnr=0;
            int returvärde = 0;
            nyttnr=ControlRow(row, col);

            if (nyttnr != 0) returvärde = nyttnr;
            
            return returvärde;
        }


    }
}
