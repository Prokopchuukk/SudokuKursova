using System;
using System.Collections.Generic;

namespace SudokuKursova
{
    internal class Field
    {
        private int[,] matrix = new int[9, 9];
        public int[,] Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        public bool IsCorrectCell(int value, int x, int y)
        {
            if (value > 0 && value < 10)
            {
                if (x >= 0 && x < 9 && y >= 0 && y < 9)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsRulesCell(int value, int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                if (matrix[i, y] == value || matrix[x, i] == value)
                {
                    return false;
                }
            }

            int startX = (x / 3) * 3;
            int startY = (y / 3) * 3;

            for (int i = startX; i < startX + 3; i++)
            {
                for (int j = startY; j < startY + 3; j++)
                {
                    if (matrix[i, j] == value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool InputCell(int value, int x, int y)
        {
            if (IsCorrectCell(value, x, y) && IsRulesCell(value, x, y))
            {
                matrix[x, y] = value;
                return true;
            }
            return false;
        }

        public void DeleteCell(int x, int y)
        {
            matrix[x, y] = 0;
        }

        public void Print()
        {
            Console.Write("   ");
            for (int i = 0; i < 9; i++)
            {
                Console.Write(i + " ");
                if ((i + 1) % 3 == 0 && i != 0)
                {
                    Console.Write("  ");
                }
            }
            Console.WriteLine();

            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine(" -----------------------");
                }

                Console.Write(i + "| ");
                for (int j = 0; j < 9; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    else
                    {
                        Console.Write("* ");
                    }

                    if ((j + 1) % 3 == 0 && j != 8)
                    {
                        Console.Write("| ");
                    }
                }
                Console.WriteLine();
            }
        }

        public bool IsFullyFilled()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void GenerateSudoku(int remainingNumbers)
        {
            remainingNumbers = 81 - remainingNumbers;
            SudokuGenerator sudokuGenerator = new SudokuGenerator();
            matrix = sudokuGenerator.GenerateSolution();

            Random random = new Random();
            List<Tuple<int, int>> points = new List<Tuple<int, int>>();

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    points.Add(new Tuple<int, int>(x, y));
                }
            }

            while (remainingNumbers > 0)
            {
                int randomIndex = random.Next(points.Count);
                Tuple<int, int> randomPoint = points[randomIndex];
                int x = randomPoint.Item1;
                int y = randomPoint.Item2;
                DeleteCell(x, y);
                points.RemoveAt(randomIndex);
                remainingNumbers--;
               
            }
        }
    }
}
