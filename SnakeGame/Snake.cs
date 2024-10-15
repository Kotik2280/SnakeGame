using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake
    {
        public MyPoint Head { get { return Body[0]; } set { Body[0] = value; } }
        public List<MyPoint> Body { get; set; }
        bool isGrowing;

        public Snake(MyPoint startPos)
        {
            Body = new List<MyPoint>();
            Body.Add(startPos);
            isGrowing = false;
        }

        public void MoveUp()
        {
            Body.Insert(0, new MyPoint(Body[0].X, Body[0].Y - 1));
            if (isGrowing)
                isGrowing = false;
            else
                Body.RemoveAt(Body.Count - 1);
        }

        public void MoveDown()
        {
            Body.Insert(0, new MyPoint(Body[0].X, Body[0].Y + 1));
            if (isGrowing)
                isGrowing = false;
            else
                Body.RemoveAt(Body.Count - 1);
        }

        public void MoveRight()
        {
            Body.Insert(0, new MyPoint(Body[0].X + 1, Body[0].Y));
            if (isGrowing)
                isGrowing = false;
            else
                Body.RemoveAt(Body.Count - 1);
        }

        public void MoveLeft()
        {
            Body.Insert(0, new MyPoint(Body[0].X - 1, Body[0].Y));
            if (isGrowing)
                isGrowing = false;
            else
                Body.RemoveAt(Body.Count - 1);
        }

        public void Grow()
        {
            isGrowing = true;
        }
    }
}
