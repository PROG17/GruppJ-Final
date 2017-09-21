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
        int[,] board = new int[9,9];
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
                    board[i, j] = (int) Char.GetNumericValue(nums[index]);
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
        }//Skriver ut spelbrädet

        public void solve()
        {
            while (!solved) //Lopp som upprepas till pusslet är löst
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        var temp = board[i, j]; //Variabel får värdet i aktuell cell
                        if (temp == 0)//Om värdet är 0
                        {
                            List<int> numbersPrintedList = new List<int>(); //Lista att spara ner färdiga värden i cellens rad, kolumn och box
                            numbersPrintedList = SearchLines(i, j); //Hämta in färdiga värden som inte kan skrivas ut
                            List<int> validNumbers = new List<int>(); //Lista för möjliga siffror
                            for (int k = 1; k <= 9; k++)
                            {
                                validNumbers.Add(k);   //Fyll listan med siffror 1-9
                            }
                            foreach (var item in numbersPrintedList)
                            {
                                validNumbers.Remove(item); //Plocka bort siffror som redan finns i cellens "fält"
                            }

                            Console.WriteLine("Nr upptagna från cell");
                            foreach (var item in numbersPrintedList) ////Skriver ut redan existerande värden (Endast kontroll)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("\nMöjliga nr");
                            foreach (var item in validNumbers) ////Skriver ut redan existerande värden (Endast kontroll)
                            {
                                Console.WriteLine(item);
                            }
                            Console.ReadKey();

                        }
                        
                    }
                }
            }
        }


        private List<int> SearchLines(int row, int col) //Hämtar siffror i cellens rad, kol och box
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
    }
}
