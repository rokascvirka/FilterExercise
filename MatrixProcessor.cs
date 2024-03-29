﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FilterExercise
{
    public class MatrixProcessor
    {
        private byte[,] Matrix { get; set; }
        public byte this[int index]
        {
            get { return ReturnIndexValue(index) ; }
            set { SetIndexValue(index, value);}
        }
        public byte[] this[Range range] => ReturnValuesInRange(range);

        public int this[int row, int col]
        {
            get { return ReturnAbsoluteIndex(row, col); }
        }

        public MatrixProcessor(byte[,] matrix)
        {
            Matrix = matrix;
        }

        public static byte[,] GenerateMatrix()
        {
            int rows = 3;
            int cols = 3;
            byte[,] matrix = new byte[rows, cols];
            byte num = 0;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = num;
                    num++;
                }
            return matrix;
        }

        public static byte[,] GenerateRandomByteMatrix()
        {
            Random random = new Random();
            int rows = 3;
            int cols = 3;
            byte[,] matrix = new byte[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    byte randomByte = (byte)random.Next(0, 255);
                    matrix[i, j] = randomByte;
                }
            return matrix;
        }

        private byte ReturnIndexValue(int index)
        {
            int rows = Matrix.GetLength(0);
            int cols = Matrix.GetLength(1);
            int rowIndex = index / rows;
            int columnIndex = index % cols;

            return Matrix[rowIndex, columnIndex];
        }

        private void SetIndexValue(int index, byte value)
        {
            int rows = Matrix.GetLength(0);
            int cols = Matrix.GetLength(1);
            int rowIndex = index / rows;
            int columnIndex = index % cols;
            Matrix[rowIndex, columnIndex] = value;
        }
        private byte[] ReturnValuesInRange(Range range)
        {
            var matrix1d = ConvertToArray(Matrix);
            return matrix1d[range];
        }

        private byte[] ConvertToArray(byte[,] byteArray)
        {
            return Matrix.Cast<byte>().ToArray();
        }

        private int ReturnAbsoluteIndex(int row, int column)
        {
            int totalCol = Matrix.GetLength(1);
            int absoluteIndex = row * totalCol + column;
            return absoluteIndex;
        }

        private void SetAbsoluteValue(int row, int column, int value)
        {
            int absoluteIndex = ReturnAbsoluteIndex(row, column);
            absoluteIndex = value;
        }
    }

}
