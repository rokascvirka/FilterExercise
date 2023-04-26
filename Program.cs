using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FilterExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string FILE_PATH = @"C:\Users\rokas.cvirka\Documents\grey.jpg";

            var image = ImageProcessor.OpenImage(FILE_PATH);

            var converted = ImageProcessor.ConvertToByteArray(image);

            var filtered = ImageProcessor.ApplyAverageFilter(converted);

            var output = ImageProcessor.ConvertToBitmap(filtered);
         //   ImageProcessor.PrintByteArray(converted);
            output.Save(@"C:\Users\rokas.cvirka\Documents\new_grey.jpg");
            output.Save("filtered_image.png", System.Drawing.Imaging.ImageFormat.Png);
            Console.WriteLine();        
            
            var testMatrixTwo = new MatrixProcessor(converted);

            var currentIndexValue = testMatrixTwo[2];

            Console.WriteLine($"Current index value is: {currentIndexValue}");

            var valueAfterChange = testMatrixTwo[2] = 34;

            Console.WriteLine($"Index value now: {valueAfterChange}");

            Console.WriteLine(testMatrixTwo[2]);

            var valuesInRange = testMatrixTwo[..4];

            Console.WriteLine(String.Join(",", valuesInRange));

        }
    }
}