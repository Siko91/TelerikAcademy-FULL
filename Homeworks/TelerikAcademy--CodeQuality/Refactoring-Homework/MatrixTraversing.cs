﻿using System;

namespace MatrixTraversing
{
    public class MatrixTraversing
    {
        private static int currentValue = 1;
        private readonly static int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private readonly static int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        private static int[,] GenerateMatrix(int matrixSize)
        {
            currentValue = 1;
            int[,] matrix = new int[matrixSize, matrixSize];
            int row = 0, col = 0;

            FillMatrix(matrix, ref row, ref col);
            FindFirstFreeCell(matrix, out row, out col);
            currentValue++;
            if (matrixSize > 3)
            {
                FillMatrix(matrix, ref row, ref col);
            }

            return matrix;
        }

        private static void FillMatrix(int[,] matrix, ref int row, ref int col)
        {
            int currentDirectionX = 1;
            int currentDirectionY = 1;

            while (true)
            {
                matrix[row, col] = currentValue;

                if (!IsBorderReached(matrix, row, col))
                {
                    return;
                }

                while ((row + currentDirectionX >= matrix.GetLength(0) || row + currentDirectionX < 0 ||
                        col + currentDirectionY >= matrix.GetLength(0) || col + currentDirectionY < 0) ||
                       (matrix[row + currentDirectionX, col + currentDirectionY] != 0))
                {
                    ChangeCurrentDirection(ref currentDirectionX, ref currentDirectionY);
                }

                row += currentDirectionX;
                col += currentDirectionY;
                currentValue++;
            }
        }

        private static void ChangeCurrentDirection(ref int currentDirectionX, ref int currentDirectionY)
        {
            int currentDirection = 0;
            for (int count = 0, len = directionsX.Length; count < len; count++)
            {
                if (directionsX[count] == currentDirectionX &&
                    directionsY[count] == currentDirectionY)
                {
                    currentDirection = count;
                    break;
                }
            }

            if (currentDirection == directionsX.Length - 1)
            {
                currentDirectionX = directionsX[
                    (currentDirection + 1) % directionsX.Length];
                currentDirectionY = directionsY[
                    (currentDirection + 1) % directionsX.Length];
            }
            else
            {
                currentDirectionX = directionsX[currentDirection + 1];
                currentDirectionY = directionsY[currentDirection + 1];
            }
        }

        private static bool IsBorderReached(int[,] arr, int x, int y)
        {
            int[] borderDetectionX = (int[])directionsX.Clone();
            int[] borderDetectionY = (int[])directionsY.Clone();

            for (int i = 0; i < borderDetectionX.Length; i++)
            {
                if ((x + borderDetectionX[i] >= arr.GetLength(0)) ||
                    (x + borderDetectionX[i] < 0))
                {
                    borderDetectionX[i] = 0;
                }

                if ((y + borderDetectionY[i] >= arr.GetLength(0)) ||
                    (y + borderDetectionY[i] < 0))
                {
                    borderDetectionY[i] = 0;
                }
            }

            for (int i = 0; i < borderDetectionX.Length; i++)
            {
                if (arr[(x + borderDetectionX[i]),
                    (y + borderDetectionY[i])] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static void FindFirstFreeCell(int[,] matrix, out int emptyCellAtXPos, out int emptyCellAtYPos)
        {
            emptyCellAtXPos = 0;
            emptyCellAtYPos = 0;

            for (int row = 0, rowLen = matrix.GetLength(0); row < rowLen; row++)
            {
                for (int col = 0, colLen = matrix.GetLength(1); col < colLen; col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        emptyCellAtXPos = row;
                        emptyCellAtYPos = col;
                        return;
                    }
                }
            }
        }

        private static void PrintMatrix(int[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write("{0}{1}", matrix[row, col], new string(' ',
                        ((size * size).ToString().Length) - matrix[row, col].ToString().Length + 1));
                }

                Console.WriteLine();
            }
        }

        public static int[,] InitializeMatrix(int size)
        {
            return GenerateMatrix(size);
        }

        static void Main(string[] args)
        {
            Console.Write("Input size of matrix: ");
            string sizeInput = Console.ReadLine();
            int size;

            bool isValidInput = int.TryParse(sizeInput, out size);

            if (isValidInput && (0 < size && size < 101))
            {
                int[,] matrix = InitializeMatrix(size);
                PrintMatrix(matrix, size);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Input number must be between 1 and 100.");
            }
        }
    }
}