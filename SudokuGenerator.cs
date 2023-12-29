using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuKursova
{
    public class SudokuGenerator
    {
        private int[,] solutionMatrix = new int[9, 9];
        private Random random = new Random();

        public int[,] GenerateSolution()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    solutionMatrix[i, j] = 0;
                }
            }

            GenerateSolutionRecursive();

            return solutionMatrix;
        }

        private bool GenerateSolutionRecursive()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (solutionMatrix[i, j] == 0)
                    {
                        List<int> shuffledValues = GetShuffledValues();

                        foreach (int value in shuffledValues)
                        {
                            if (IsSafe(i, j, value))
                            {
                                solutionMatrix[i, j] = value;

                                if (GenerateSolutionRecursive())
                                {
                                    return true;
                                }

                                solutionMatrix[i, j] = 0;
                            }
                        }

                        return false;
                    }
                }
            }

            return true;
        }

        private List<int> GetShuffledValues()
        {
            List<int> values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int n = values.Count;

            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                int value = values[k];
                values[k] = values[n];
                values[n] = value;
            }

            return values;
        }

        private bool IsSafe(int row, int col, int num)
        {
            return !UsedInRow(row, num) && !UsedInCol(col, num) && !UsedInBox(row - row % 3, col - col % 3, num);
        }

        private bool UsedInRow(int row, int num)
        {
            for (int col = 0; col < 9; col++)
            {
                if (solutionMatrix[row, col] == num)
                {
                    return true;
                }
            }
            return false;
        }

        private bool UsedInCol(int col, int num)
        {
            for (int row = 0; row < 9; row++)
            {
                if (solutionMatrix[row, col] == num)
                {
                    return true;
                }
            }
            return false;
        }

        private bool UsedInBox(int startRow, int startCol, int num)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (solutionMatrix[startRow + row, startCol + col] == num)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
