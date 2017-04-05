using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileVisualizer
{





    class Program
    {
        static void Main(string[] args)
        {
            string inputFilename = @"C:\Users\steve\AppData\Local\Introversion\Prison Architect\saves\Walls.prison";
            string outputFilename = @"D:\sap.png";

            var data = File.ReadAllBytes(inputFilename);
            int dimensions = (int)Math.Ceiling(Math.Sqrt(data.Length));
            var bm = new Bitmap(dimensions, dimensions);

            for (var i = 0; i < data.Length; ++i)
            {
                char c = (char) data[i];
                Color color = Color.Green;
                if (c >= '0' && c <= '9')
                    color = Color.White;
                else if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                    color = Color.Blue;
                else if (c == '\r' || c == '\n')
                    color = Color.GreenYellow;
                bm.SetPixel(i % dimensions, i / dimensions, color);
            }
            for (var i = data.Length; i < dimensions * dimensions; ++i)
                bm.SetPixel(i % dimensions, i / dimensions, Color.Red);

            bm.Save(outputFilename);
        }
    }
}
