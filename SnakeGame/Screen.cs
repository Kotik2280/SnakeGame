using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Screen
    {
        public int Width { get; set; }
        public int Height { get; set; }

        private char[,] matrix;
        public char FillSymbol { get; private set; }
        public char VoidSymbol { get; private set; }

        public Screen(int width, int height, char fillSymbol, char voidSymbol)
        {
            Width = width;
            Height = height;

            FillSymbol = fillSymbol;
            VoidSymbol = voidSymbol;

            matrix = new char[width, height];
            ClearScreen();
        }

        public void SetPixel(int x, int y)
        {
            matrix[x, y] = FillSymbol;
        }
        public void SetPixel(MyPoint point)
        {
            matrix[point.X, point.Y] = FillSymbol;
        }
        public void SetPixels(IEnumerable<MyPoint> points)
        {
            foreach (MyPoint point in points)
            {
                matrix[point.X, point.Y] = FillSymbol;
            }
        }
        public bool GetPixel(int x, int y)
        {
            return matrix[x, y] == FillSymbol;
        }

        public void ClearScreen()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    matrix[x, y] = VoidSymbol;
                }
            }
        }
        public void ShowScreen()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(matrix[x, y]);
                }
            }
        }
    }
}
