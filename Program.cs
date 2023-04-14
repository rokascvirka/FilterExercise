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

            var filtered = ImageProcessor.CountNoise(converted);

            var output = ImageProcessor.ConvertToBitmap(filtered);
            output.Save(@"C:\Users\rokas.cvirka\Documents\new_grey.jpg");
            output.Save("filtered_image.png", System.Drawing.Imaging.ImageFormat.Png);
            Console.WriteLine();
         }
    }
}