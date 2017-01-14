using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    class Matrix<T>
    {
        private T[,] matrix;

        public Matrix(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
            {
                throw new ArgumentException("rows and cols must be positive numbers.");
            }

            this.matrix = new T[rows, cols];
        }

        public int Row
        {
            get { return this.matrix.GetLength(0); }
        }

        public int Col
        {
            get { return this.matrix.GetLength(1); }
        }

        public T this[int row, int col]
        {
            get { return this.matrix[row, col]; }
            set { this.matrix[row, col] = value; }
        }

        public static Matrix<T> Add(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Row != secondMatrix.Row || firstMatrix.Col != secondMatrix.Col)
            {
                throw new ArgumentException("The two Matrix<T> are of different sizes");
            }

            Matrix<T> newMatrix = firstMatrix;

            for (int r = 0; r < firstMatrix.Row; r++)
            {
                for (int c = 0; c < firstMatrix.Col; c++)
                {
                    newMatrix[r, c] += (dynamic)secondMatrix[r, c];
                }
            }
            return newMatrix;
        }
        public static Matrix<T> Substract(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Row != secondMatrix.Row || firstMatrix.Col != secondMatrix.Col)
            {
                throw new ArgumentException("The two Matrix<T> are of different sizes");
            }

            Matrix<T> newMatrix = firstMatrix;

            for (int r = 0; r < firstMatrix.Row; r++)
            {
                for (int c = 0; c < firstMatrix.Col; c++)
                {
                    newMatrix[r, c] -= (dynamic)secondMatrix[r, c];
                }
            }
            return newMatrix;
        }
        public static Matrix<T> Multiply(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Row != secondMatrix.Col || firstMatrix.Col != secondMatrix.Row)
            {
                throw new ArgumentException("The two Matrix<T> matrixes can not be multiplied.");
            }

            Matrix<T> newMatrix = new Matrix<T>(firstMatrix.Row,secondMatrix.Col);

            for (int r = 0; r < newMatrix.Row; r++)
            {
                for (int c = 0; c < newMatrix.Col; c++)
                {
                    for (int el = 0; el < firstMatrix.Col; el++)
                    {
                        newMatrix[r, c] += (firstMatrix[r, el] * (dynamic)secondMatrix[el, c]);
                    }
                }
            }
            return newMatrix;
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        { return Matrix<T>.Add(firstMatrix, secondMatrix); }
        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        { return Matrix<T>.Substract(firstMatrix, secondMatrix); }
        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        { return Matrix<T>.Multiply(firstMatrix, secondMatrix); }


        public static bool operator true(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Row; row++)
            {
                for (int col = 0; col < matrix.Col; col++)
                {
                    if ((dynamic)matrix[row, col] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Row; row++)
            {
                for (int col = 0; col < matrix.Col; col++)
                {
                    if ((dynamic)matrix[row, col] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}
