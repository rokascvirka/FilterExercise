using System;
using System.Drawing;
using System.Xml.Serialization;

namespace FilterExercise
{
    public class ImageProcessor
    {
        public static Bitmap OpenImage(string filePath)
        {
            return new Bitmap(filePath);
        }
        
        public static byte[,] ConvertToByteArray(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            byte[,] byteArray = new byte[height, width];
            
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int value = pixelColor.R;
                    byteArray[y, x] = (byte)value;
                }
            }
            return byteArray;
        }

        public static Bitmap ConvertToBitmap(byte[,] filteredArray)
        {
            int height = filteredArray.GetLength(0); 
            int width = filteredArray.GetLength(1); 

            Bitmap image = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte pixelValue = filteredArray[y, x]; 
                    Color pixelColor = Color.FromArgb(pixelValue, pixelValue, pixelValue);
                    image.SetPixel(x, y, pixelColor);
                }
            }
            return image;
        }

        public static byte[,] CountNoise(byte[,] byteArray)
        {
            int height = byteArray.GetLength(0);
            int width = byteArray.GetLength(1);

            byte[,] outputArray = new byte[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int sum = 0;
                    int count = 0;

                    for (int offsetY = -1; offsetY <= 1; offsetY++)
                    {
                        for (int offsetX = -1; offsetX <= 1; offsetX++)
                        {
                            if (offsetX == 0 && offsetY == 0)
                            {
                                continue;
                            }

                            int newY = y + offsetY;
                            int newX = x + offsetX;

                            if (newX >= 0 && newY >= 0 && newX < width && newY < height)
                            {
                                sum += byteArray[newY, newX];
                                count++;
                            }
                        }
                    }

                    int average = sum / count;

                    outputArray[y, x] = (byte)average;
                }
            }

            return outputArray;
        }

        public static void PrintByteArray(byte[,] byteArray)
        {
            var rowCount = byteArray.GetLength(0);
            var colCount = byteArray.GetLength(1);
            for (int row = 0; row < rowCount; row++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                for (int col = 0; col < colCount; col++)
                    Console.Write(String.Format("{0}\t", byteArray[row, col]));
                Console.WriteLine();
            }
        }



    }
}
