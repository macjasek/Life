using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    class Tablica
    {
        public int[,] Array { get; set; }
        public int[,] HideArray { get; set; }
        public int[,] ColourArray { get; set; }

        public Tablica()
        {

        }

        public Tablica (int size)
        {
            Array = new int[size,size];
            HideArray = new int[size, size];
            ColourArray = new int[size, size];
        }

        public void FillTab()
        {
            Random rnd = new Random();

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(0); j++)
                {
                    var myValue = rnd.Next(0, 2);
                    Array[i, j] = myValue;
                    ColourArray[i, j] = 0;
                }
            }

        }


        public void printArray()
        {
            
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(0); j++)
                {
                    MyConsoleColour(ColourArray[i, j]);
                    if (Array[i,j] == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("@");
                    }

                    Console.ResetColor();
                }
                Console.WriteLine();
            }

        }

        public void MyConsoleColour(int colour)
        {
            switch (colour)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    break;
            }
        }

        public void ProcessArray()
        {
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(0); j++)
                {
                    var sum = 0;

                    var cell= Array[i, j];

                    sum = TestArray(i, j);

                    if (cell == 1)
                    {
                        if (sum == 2 || sum == 3)
                        {
                            HideArray[i, j] = 1;
                        }
                        else
                        {
                            HideArray[i, j] = 0;
                        }
                    }
                    else
                    {
                        if (sum == 3)
                        {
                            HideArray[i, j] = 1;
                            if (ColourArray[i, j] == 5)
                            {
                                ColourArray[i, j] = 1;
                            }
                            else
                            {
                                ColourArray[i, j]++;
                            }
                        }
                        else
                        {
                            HideArray[i, j] = 0;
                        }            
                    }
                }
            }

            Array = HideArray;
        }
        

        public int TestArray(int i, int j)
        {
            var sum = 0;
            int sizeI = Array.GetLength(0);
            int sizeJ = Array.GetLength(1);

            if (i>0 && j>0)
            {
                sum = sum + Array[i - 1, j - 1];
            }
            if (j > 0)
            {
                sum = sum + Array[i, j - 1];
            }
            if (i < Array.GetLength(0)-1 && j > 0)
            {
                sum = sum + Array[i + 1, j - 1];
            }
            if (i > 0)
            {
                sum = sum + Array[i - 1, j];
            }
            if (i < Array.GetLength(0)-1)
            {
                sum = sum + Array[i + 1, j];
            }
            if (i > 0 && j < Array.GetLength(1)-1)
            {
                sum = sum + Array[i - 1, j + 1];
            }
            if (j < Array.GetLength(1)-1)
            {
                
                sum = sum + Array[i, j + 1];
            }
            if (i < Array.GetLength(0)-1 && j < Array.GetLength(1)-1)
            {
                sum = sum + Array[i + 1, j + 1];
            }
            return sum;

        }
   


    }
}
