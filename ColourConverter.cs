using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RGBNeuralNet
{
    public static class ColourConverter
    {
        public static List<double> Convert(string colour)
        {
            List<double> values = new List<double>(3);

            ColorConverter converter = new ColorConverter();
            Color temp = (Color)converter.ConvertFromInvariantString(colour);

            double red = (1.0d - (1.0d / temp.R));
            if(temp.R == 0)
            {
                red = 0.0d;
            }
            values.Add(red);

            double green = (1.0d - (1.0d / temp.G));
            if(temp.G == 0)
            {
                green = 0.0d;
            }
            values.Add(green);

            double blue = (1.0d - (1.0d / temp.B));
            if(temp.B == 0)
            {
                blue = 0.0d;
            }
            values.Add(blue);

            Console.WriteLine("Red: " + values[0]);
            Console.WriteLine("Green: " + values[1]);
            Console.WriteLine("Blue: " + values[2]);

            return values;
        }
    }
}
