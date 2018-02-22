using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeWinForms
{
    public partial class GameForm : Form
    {
        private const int WIDTH = 45;
        private const int HEIGHT = 45;
        private const int SPEED = 100;
        private const int POINT_WIDTH = 10;
        private const int POINT_HEIGHT = 10;

        private Timer snakeTimer = new Timer();

        private Snake snake = new Snake(WIDTH, HEIGHT);
        private Point food = new Point();
        private FoodCreator foodCreator = new FoodCreator();

        private void Draw(Graphics canvas)
        {
            snake.Draw(canvas);
            food.Draw(canvas);
        }

        public GameForm()
        {
            InitializeComponent();

            snakeTimer.Tick += new EventHandler(UpdateSnake);
            snakeTimer.Interval = SPEED;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Walls walls = new Walls(WIDTH, HEIGHT, Color.Brown, POINT_WIDTH, POINT_HEIGHT);
            walls.Draw();*/

            // Отрисовка точек змейки
            Point p = new Point(4, 5, Color.Red, POINT_WIDTH, POINT_HEIGHT);
            snake = new Snake(p, 4, Direction.RIGHT, WIDTH, HEIGHT);

            // Создание еды
            foodCreator = new FoodCreator(WIDTH, HEIGHT, Color.Yellow, POINT_WIDTH, POINT_HEIGHT);
            food = foodCreator.CreateFood();

            pbCanvas.Invalidate();

            snakeTimer.Start();
        }

        private void UpdateSnake(object sender, EventArgs e)
        {
            if (snake.IsHitWalls() || snake.IsHitTail())
            {
                snakeTimer.Stop();
                return;
            }

            if (snake.Eat(food))
                food = foodCreator.CreateFood();
            else
                snake.Move();

            pbCanvas.Invalidate();

            if (Input.Press(Keys.Escape))
            {
                snakeTimer.Stop();
                return;
            }
            else
            {
                snake.HandleKey();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Autor: Vladimir Savchenko");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }
    }
}
