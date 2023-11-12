using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Rectangle
    {
        private Point topLeft;
        private Point bottomRight;

        public Point getTopLeft() { return this.topLeft; }
        public Point getBottonRight() { return this.bottomRight; }

        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }

        public int Area()
        {
            int length = bottomRight.X - topLeft.X;
            int width = bottomRight.Y - topLeft.Y;
            return Math.Abs(length * width);
        }

        public bool IntersectsWith(Rectangle other)
        {
            return topLeft.X < other.bottomRight.X && bottomRight.X > other.topLeft.X &&
                   topLeft.Y < other.bottomRight.Y && bottomRight.Y > other.topLeft.Y;
        }
    }
}
