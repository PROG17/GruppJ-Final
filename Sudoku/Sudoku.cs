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

        private int UNASSIGNED = 0;
        public void Solve()
        {
            bool solved = false;
            int noHit = 0;
            while (solved == false)
            {
               
                solved = true;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (board[i, j] == 0)  //Om nuvarande cell innehåller värdet 0 så:
                        {
                            noHit = 0;
                            solved = false;
                            board[i,j] = Search(i, j); //Anropa metod som tilldelar cellen sitt logiskt möjliga värde
                            if (board[i, j] != 0) noHit = board[i, j];
                        }
                        
                    }
                    //Console.Clear();
                    //DisplayBoard();
                    //Thread.Sleep(50);
                }
                if (noHit == 0) {SolveSudoku(board); }
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
        bool SolveSudoku(int[,] board)
        {
            do
            {
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (!FindUnassignedLocation(board, row, col))
                            return true; // Brädet fullt!

                        if (CurrentUnassigned(board, row, col))
                        {
                            for (int val = 1; val <= 9; val++) // 1-9
                            {
                                if (NoConflicts(row, col, val, board) == true) //Om # är möjlig
                                {

                                    board[row, col] = val;  //Försök sätta ut # 

                                    if (board[row, col] != 0)
                                    {
                                        if (SolveSudoku(board)) return true;
                                    }
                                    board[row, col] = UNASSIGNED; //Ta bort och försök igen


                                }
                                if (row == 0 && col == 0 && val == 9)
                                {
                                    Console.WriteLine("Can't be solved! =(");
                                    return false;
                                }
                            }
                            if (board[row, col] == UNASSIGNED) return false;
                        }
                    }

                    //Console.Clear();
                    //DisplayBoard();
                    //Thread.Sleep(50);
                }

                return false;//Aktiverar Backtracking
            } while (true);




        }
        public bool FindUnassignedLocation(int[,] board, int row, int col) //Om return=True så hittade den en Nolla
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] == 0) return true;
                }
            }
            return false;
        }
        public bool CurrentUnassigned(int[,] board, int row, int col)
        {
            if (board[row, col] == UNASSIGNED) return true;
            return false;
        }

        static bool CheckRow(int row, int val, int[,] arr)
        {
            for (int i = 0; i < 9; i++)
            {
                if (arr[row, i] == val)
                {
                    return false;
                }
            }
            return true;
        }
        static bool CheckCol(int col, int val, int[,] arr)
        {
            for (int i = 0; i < 9; i++)
            {
                if (arr[i, col] == val)
                {
                    return false;
                }
            }
            return true;
        }
        static bool CheckBox(int row, int col, int val, int[,] arr)
        {
            row = (row / 3) * 3;
            col = (col / 3) * 3;
            int colreset = col;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr[row, col] == val)
                    {
                        return false;
                    }
                    col++;
                }
                row++;
                col = colreset;
            }
            return true;
        }
        static bool NoConflicts(int row, int col, int val, int[,] arr)
        {
            if (!CheckRow(row, val, arr)) return false;
            if (!CheckCol(col, val, arr)) return false;
            if (!CheckBox(row, col, val, arr)) return false;
            return true;
        }
    }
}
