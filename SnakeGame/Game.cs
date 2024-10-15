using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Game
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        private Direction currentDirection;
        private ConsoleKeyInfo userInput;

        private Snake player;
        private Screen screen;

        private bool isAlive;
        private double gameSpeed;

        List<MyPoint> food;

        public Game(Screen screen, MyPoint playerPossition, double speed, int maxFoodCount = 1)
        {
            this.screen = screen;
            player = new Snake(playerPossition);
            isAlive = true;
            gameSpeed = speed;

            currentDirection = Direction.Right;
            food = new List<MyPoint>();
            AddFood(maxFoodCount);
        }
        public void AddFood(int count)
        {
            Random random = new Random();

            List<MyPoint> correctFoodPossitions = new List<MyPoint>();

            for (int y = 0; y < screen.Height; y++)
            {
                for (int x = 0; x < screen.Width; x++)
                {
                    bool flag = false;
                    foreach (MyPoint point in player.Body)
                    {
                        if (screen.GetPixel(x, y))
                            flag = true;
                            break;
                    }
                    if (!flag)
                        correctFoodPossitions.Add(new MyPoint(x, y));
                }
            }

            for (int i = 0; i < count; i++)
            {
                MyPoint point = correctFoodPossitions[random.Next(0, correctFoodPossitions.Count)];
                correctFoodPossitions.Remove(point);
                food.Add(point);
            }
        }
        public void Start()
        {
            while (isAlive)
            {
                Process();
                Thread.Sleep((int)Math.Round(100/gameSpeed));
            }

            Console.WriteLine("\nИгра окончена!");
        }
        async public void Process()
        {
            screen.ClearScreen();
            screen.SetPixels(player.Body);
            screen.SetPixels(food);
            screen.ShowScreen();
            Control();
            CheckFood();
            await GetInput();
            SetCurrentDirection();
            
        }
        private void CheckFood()
        {
            for (int i = 0; i < food.Count; i++)
            {
                if (player.Head == food[i])
                {
                    food.RemoveAt(i);
                    player.Grow();
                    AddFood(1);
                    return;
                }
            }
        }
        async private Task GetInput()
        {
            userInput = await Task.Run(() => Console.ReadKey());
        }
        public void SetCurrentDirection()
        {
            switch (userInput.Key)
            {
                case ConsoleKey.W:
                    currentDirection = Direction.Up;
                    break;
                case ConsoleKey.S:
                    currentDirection = Direction.Down;
                    break;
                case ConsoleKey.A:
                    currentDirection = Direction.Left;
                    break;
                case ConsoleKey.D:
                    currentDirection = Direction.Right;
                    break;
                default:
                    break;
            }
        }
        public void Control()
        {
            if (!isPlayerInValidPossition())
            {
                isAlive = false;
                return;
            }

            switch (currentDirection)
            {
                case Direction.Up:
                    player.MoveUp();
                    break;
                case Direction.Down:
                    player.MoveDown();
                    break;
                case Direction.Left:
                    player.MoveLeft();
                    break;
                case Direction.Right:
                    player.MoveRight();
                    break;
                default:
                    break;
            }
        }
        public bool isPlayerInValidPossition()
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    if (player.Head.Y < 1)
                        return false;
                    break;
                case Direction.Down:
                    if (player.Head.Y > screen.Height - 2)
                        return false;
                    break;
                case Direction.Left:
                    if (player.Head.X < 1)
                        return false;
                    break;
                case Direction.Right:
                    if (player.Head.X > screen.Width - 2)
                        return false;
                    break;
            }

            if (player.Body.Count == 1)
                return true;

            for (int i = 1; i < player.Body.Count; i++)
            {
                if (player.Body[i] == player.Head)
                    return false;
            }

            return true;
        }
        private void MoveUp()
        {
            if (player.Head.Y > 0)
            {
                player.Head.Y--;
            }
        }
    }
}
