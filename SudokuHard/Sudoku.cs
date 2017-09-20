﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SudokuHard
{
    class Sudoku
    {
        //fields
        private string nums = "";
        private int index = 0;
        int[,] board = new int[9,9];
        private bool solved = false;
        List<int> numbersOnRow = new List<int>();

        //constructor
        public Sudoku(string num)
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
                    board[i, j] = (int) Char.GetNumericValue(nums[index]);
                    index++;
                }
            }
            DisplayBoard();
        }

        private void DisplayBoard()
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
                    Console.WriteLine("-------------");
                }

            }
        }

        public void solve()
        {
            while (!solved)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        var temp = board[i, j];
                        if (temp == 0)
                        {
                            numbersOnRow = SearchRow(i);
                        }
                    }
                }
            }
        }


        private List<int> SearchRow(int row)
        {
            
            List<int> numbersFound = new List<int>();

            for (int j = 0; j < 9; j++)
            {
                var temp = board[row, j];
                if (temp > 0)
                {
                    numbersFound.Add(temp);
                }
            }
            return numbersFound;
            


        }
    }
}
