using System;
using System.Linq;
using System.Windows.Forms;

namespace SnakeWinForms
{
    class Snake : Figure
    {
        private Direction direction;
        private int width;
        private int height;

        public Snake(int _width, int _height) : base()
        {
            width = _width;
            height = _height;
        }

        public Snake(Point tail, int length, Direction _direction, int _width, int _height)
        {
            direction = _direction;
            width = _width;
            height = _height;
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        public void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        public void HandleKey()
        {
            if (Input.Press(Keys.Left))
            {
                direction = Direction.LEFT;
            }
            else if (Input.Press(Keys.Right))
            {
                direction = Direction.RIGHT;
            }
            else if (Input.Press(Keys.Down))
            {
                direction = Direction.DOWN;
            }
            else if (Input.Press(Keys.Up))
            {
                direction = Direction.UP;
            }
        }

        public bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }

        public bool IsHitWalls()
        {
            var head = pList.Last();
            if (head.IsHitHorizontal(width) || head.IsHitVertical(height))
                return true;
            return false;
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.color = head.color;
                pList.Add(food);
                return true;
            }
            else
                return false;
        }
    }
}
