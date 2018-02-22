using System.Drawing;

namespace SnakeWinForms
{
    class Point
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public Color color;

        public Point() { }
        public Point(int _x, int _y, Color _color, int _width, int _height)
        {
            x = _x * _width;
            y = _y * _height;
            width = _width;
            height = _height;
            color = _color;
        }

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            width = p.width;
            height = p.height;
            color = p.color;
        }

        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                x = x + offset * width;
            }
            else if (direction == Direction.LEFT)
            {
                x = x - offset * width;
            }
            else if (direction == Direction.UP)
            {
                y = y - offset * height;
            }
            else if (direction == Direction.DOWN)
            {
                y = y + offset * height;
            }
        }

        public bool IsHitHorizontal(int w)
        {
            return x < 0 || x >= w * width;
        }

        public bool IsHitVertical(int h)
        {
            return y < 0 || y >= h * height;
        }

        public bool IsHit(Point p)
        {
            return x == p.x && y == p.y;
        }

        public void Draw(Graphics canvas)
        {
            Rectangle rect = new Rectangle(x, y, width, height);
            Brush brush = new SolidBrush(color);
            canvas.FillRectangle(brush, rect);
        }
    }
}
