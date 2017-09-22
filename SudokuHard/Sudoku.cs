using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SudokuHard
{
    class Sudoku
    {
        //fields
        private string nums = "";
        private int index = 0;
        int UNASSIGNED = 0;
        static int[,] board = new int[9, 9];


        public Sudoku(string num) //Tar emot sträng med "spelet" och konverterar till spelbräde.
        {
            nums = num;
            BoardBuilder();
        }

        //metoder
        private void BoardBuilder()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = (int)Char.GetNumericValue(nums[index]);
                    index++;
                }
            }
            DisplayBoard();
        } //Skapar spelbräda

        private void DisplayBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i, j]);
                    if (j == 2 || j == 5)
                    {
                        Console.Write("|");
                    }

                }
                Console.WriteLine();
                if (i == 2 || i == 5)
                {
                    Console.WriteLine("-------------");
                }

            }
        }//Skriver ut spelbrädet
        
        public void Solve()
        {
            bool solved = SolveSudoku(board);
            Console.WriteLine("To solve, press any key");
            Console.ReadKey();
            if (solved == true)
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine("Solved!!\n");
                
            }
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
                            }
                            if (board[row, col] == UNASSIGNED) return false;
                        }
                    }                  
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
