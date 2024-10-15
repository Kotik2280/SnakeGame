using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class MyPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public MyPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(MyPoint point1, MyPoint point2)
        {
            return point1.X == point2.X && point1.Y == point2.Y;
        }

        public static bool operator !=(MyPoint point1, MyPoint point2)
        {
            return point1.X != point2.X || point1.Y != point2.Y;
        }
    }
}
