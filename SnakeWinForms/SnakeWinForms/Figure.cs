using System.Collections.Generic;
using System.Drawing;

namespace SnakeWinForms
{
    class Figure
    {
        protected List<Point> pList;

        public Figure()
        {
            pList = new List<Point>();
        }

        public virtual void Draw(Graphics canvas)
        {
            foreach (Point p in pList)
            {
                p.Draw(canvas);
            }
        }

        public bool IsHit(Figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }

        private bool IsHit(Point point)
        {
            foreach (var p in pList)
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
        }
    }
}
