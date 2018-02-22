using System;
using System.Drawing;

namespace SnakeWinForms
{
    class FoodCreator
    {
        private int mapWidth;
        private int mapHeight;
        public int width;
        public int height;
        public Color color;

        private Random random = new Random();

        public FoodCreator() { }

        public FoodCreator(int mapWidth, int mapHeight, Color color, int width, int height)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.width = width;
            this.height = height;
            this.color = color;
        }

        public Point CreateFood()
        {
            int x = random.Next(2, mapWidth - 2);
            int y = random.Next(2, mapHeight - 2);
            Point food = new Point(x, y, color, width, height);
            return food;
        }
    }
}
