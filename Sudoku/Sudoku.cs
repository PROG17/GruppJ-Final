using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
                    Thread.Sleep(250);
                    Console.Clear();
                    DisplayBoard();
                }   
            }
            Console.Clear();
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

        public int ControlRow(int row, int col)
        {
            int returvärde = 0;
            int[] possible = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < possible.Length; j++)
                {
                    if (possible[j] == board[row, i]) possible[j] = 0;
                }
            }
            Array.Sort(possible);
            if (possible[8] != 0 && possible[7] == 0)
            {
                returvärde = possible[8];
                return returvärde;
            }
            else
            {
                returvärde = ControlCol(col, row, possible);
                return returvärde;
            }

        }

        private int ControlCol(int col, int row, int[] array)
        {
            int returvärde = 0;
            int[] possible = array;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < possible.Length; j++)
                {
                    if (possible[j] == board[i, col]) possible[j] = 0;
                }
            }
            Array.Sort(array);
            if (array[8] != 0 && array[7] == 0)
            {
                returvärde = array[8];
                return returvärde;
            }
            else
                returvärde = ControlBox(row, col, array);
            return returvärde;
        }
        private int ControlBox (int row, int col, int[]array)
        {
            int returvärde = 0;
            int[] possible = array;

            if (row == 1 || row == 4 || row == 7) row--;
            else if (row == 2 || row == 5 || row == 8) row = row - 2;

            if (col == 1 || col == 4 || col == 7) col--;
            else if (col == 2 || col == 5 || col == 8) col = col - 2;
            int colreset = col;

            for (int i = 0; i < 3; i++)
            {
                col = colreset;
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < possible.Length; k++)
                    {
                        if (possible[k] == board[row, col]) possible[k] = 0;
                    }
                    col++;
                }
                row++;  
            }
            Array.Sort(array);
            if (array[8] != 0 && array[7] == 0)
            {
                returvärde = array[8];
                return returvärde;
            }
            else
                
            return 0;
        }
    }
}
