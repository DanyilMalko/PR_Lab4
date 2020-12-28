using System;
using System.IO;
using System.Linq;

namespace PR_Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] myArray = GetValuesFromFile();

            ShowInputFromFile(myArray);

            for (int row = 0; row < myArray.GetLength(0); row++)
            {
                for (int column = 0; column < myArray.GetLength(1); column++)
                {
                    if (column == 0)
                        continue;
                    myArray[row, column] = Math.Round(myArray[row, 0] * myArray[row, column], 1);                   
                }
            }
            Console.WriteLine("\nResults:");
            ShowInputFromFile(myArray);

            double[] results = new double[myArray.GetLength(1)-1];

            for (int column = 0; column < myArray.GetLength(1); column++)
            {
                for (int row = 0; row < myArray.GetLength(0); row++)
                {
                    if (column == 0)
                        continue;

                    results[column - 1] =Math.Round(results[column - 1] + myArray[row, column], 1);
                }
            }

            Console.Write("Sum:                    ");
            for (int i = 0; i < results.Length; i++)
            {             
                Console.Write(results[i]+"\t");
            }
        }

        private static void ShowInputFromFile(double[,] myArray)
        {
            Console.WriteLine("Games for evaluation: \n1)Ori\n2)A way out\n3)Far Cry 5\n4)GTA 5\n5)Cyberpunk ");

            Console.WriteLine("\nGames:\t        Value | 1)\t2)\t3)\t4)\t5)");

            for (int row = 0; row < myArray.GetLength(0); row++)
            {
                StupidKostil(row);
                for (int column = 0; column < myArray.GetLength(1); column++)
                {
                    Console.Write(myArray[row, column] + "\t");
                }
                Console.WriteLine();
            }
        }
        private static void StupidKostil(int row)
        {
            switch (row)
            {
              case 0:  
                    Console.Write("Gameplay\t");
                    break;
              case 1:
                    Console.Write("Story    \t");
                    break;
              case 2:
                    Console.Write("Optimization\t");
                    break;
              case 3:
                    Console.Write("Graphiсs\t");
                    break;
              case 4:
                    Console.Write("Price    \t");
                    break;
                default:
                    Console.WriteLine("Default case\t");
                    break;
               }
        }

        private static double[,] GetValuesFromFile()
        {
            var directory = System.IO.Directory.GetCurrentDirectory();
            var allrows = File
             .ReadLines($"{directory}\\Input.txt")
             .Select(line => line.Split(" ").Select(double.Parse).ToList())
             .ToList();

            var matrix = new double[allrows.Count, allrows[0].Count];
            for (int row = 0; row != allrows.Count; row++)
            {
                for (int col = 0; col != allrows[0].Count; col++)
                {
                    matrix[row, col] = allrows[row][col];
                }
            }

            return matrix;
        }
    }
}
