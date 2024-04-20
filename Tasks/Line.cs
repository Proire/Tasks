using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Line(double x1, double y1, double x2, double y2)
    {
        public double X1 { get; set; } = x1; // Coordinate x1 of the first point
        public double Y1 { get; set; } = y1; // Coordinate y1 of the first point

        public double X2 { get; set; } = x2; // Coordinates x2 of the second point

        public double Y2 { get; set; } = y2; // Coordinates y2 of the second point


        // Method to calculate the length of the line
        public double CalculateLength()
        {
            return Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
        }
    }
}
