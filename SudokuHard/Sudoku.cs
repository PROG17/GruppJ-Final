using System;
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
        static int[,] board = new int[9, 9];
        int[,] clone = board;
        private bool solved = false;
        //List<int> numbersPrintedList = new List<int>(); //Lista att spara ner färdiga värden i cellens rad, kolumn och box

        //constructor
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

            do
            {
                Search(clone);
            } while (false);
            Console.WriteLine("Solved\n");
            DisplayBoard();
        }
        public bool Search(int[,] array)
        {
            bool solved = true;
            //while (!solved) //Lopp som upprepas till pusslet är löst
            //{
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var temp = array[i, j]; //Variabel får värdet i aktuell cell
                    if (temp == 0)//Om värdet är 0
                    {
                        solved = false;
                        List<int> numbersPrintedList = new List<int>(); //Lista att spara ner färdiga värden i cellens rad, kolumn och box
                        List<int> validNumbers = new List<int>(); //Lista för möjliga siffror
                        numbersPrintedList = GetPrintedNumbers(i, j); //Hämta in färdiga värden som inte kan skrivas ut
                        for (int k = 1; k <= 9; k++) //fyll listan med siffror 1-9
                        {
                            validNumbers.Add(k);
                        }
                        foreach (var item in numbersPrintedList) //Plocka bort siffror som redan finns i cellens "fält"
                        {
                            validNumbers.Remove(item);
                        } //Nu innehåller listan de möjliga värdena för cellen.
                        foreach (var item in validNumbers)
                        {
                            array[i, j] = item;

                            if (CheckMove(i, j, item, array) == true)
                            {
                                if (Search(array) == true)
                                {
                                    clone[i, j] = array[i, j];
                                    return true;
                                }
                            }

                        }
                        
                        //Console.WriteLine("Nr upptagna från cell");
                        //foreach (var item in numbersPrintedList)////Skriver ut redan existerande värden (Endast kontroll)
                        //{
                        //    Console.WriteLine(item);
                        //}
                        //Console.WriteLine("\nMöjliga nr");
                        //foreach (var item in validNumbers)////Skriver ut redan existerande värden (Endast kontroll)
                        //{
                        //    Console.WriteLine(item);
                        //}
                        //Console.ReadKey();

                    }

                }
            }
            if (solved == false) return false;
            else return true;
            //}
        }


        private List<int> GetPrintedNumbers(int row, int col) //Hämtar siffror i cellens rad, kol och box
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
            for (int j = 0; j < 9; j++)
            {
                var temp = board[j, col];
                if (temp > 0)
                {
                    numbersFound.Add(temp);
                }
            }
            row = (row / 3) * 3;
            col = (col / 3) * 3;
            int colreset = col;
            for (int i = 0; i < 3; i++)
            {
                col = colreset;
                for (int j = 0; j < 3; j++)
                {
                    var temp = board[row, col];
                    if (temp > 0)
                    {
                        numbersFound.Add(temp);
                    }
                    col++;
                }
                row++;
            }
            numbersFound = numbersFound.Distinct().ToList();
            return numbersFound;



        }
        static bool CheckRow(int row, int val, int[,] arr)
        {
            for (int i = 0; i < 9; i++)
            {
                if (arr[row, i] == val) return false;
            }
            return true;
        }
        static bool CheckCol(int col, int val, int[,] arr)
        {
            for (int i = 0; i < 9; i++)
            {
                if (arr[col, i] == val) return false;
            }
            return true;
        }
        static bool CheckBox(int row, int col, int val, int[,] arr)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr[row - (row % 3) + i, col - (col % 3) + j] == val) return false;
                }
            }
            return true;
        }
        static bool CheckMove(int row, int col, int val, int[,] arr)
        {
            if (!CheckRow(row, val, arr)) return false;
            if (!CheckCol(col, val, arr)) return false;
            if (!CheckBox(row, col, val, arr)) return false;
            return true;

        }

    }
}
