using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public sealed class Player : IEntity
    {
        public char Appearnace { get; set; }
        public int X { get ; set; }
        public int Y { get; set; }
        public int Health { get; set; }

        public event Action<int[], IEntity> MoveRequest;
        public Player()
        {
            Y = 0;
            X = 0;
            Health = 10;
            Appearnace = 'A';
        }
        public void innit()
        {
            Thread t = new Thread(Move);
            t.Start();
        }
        private void Move()
        {
            while (true)
            {
                int x = X;
                int y = Y;
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            {
                                x--;
                                Console.SetCursorPosition(Console.BufferWidth - 15, Y);
                                Console.WriteLine(new String(' ', 15));
                                MoveRequest.Invoke(new int[] { x, y }, this);
                                Console.SetCursorPosition(Console.BufferWidth - 15, Y);
                                Console.WriteLine($"Health - {Health}");
                            }
                            break;
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            {

                                y--;
                                Console.SetCursorPosition(Console.BufferWidth - 15, Y);
                                Console.WriteLine(new String(' ', 15));
                                MoveRequest.Invoke(new int[] {x,y},this);
                                Console.SetCursorPosition(Console.BufferWidth - 15, Y);
                                Console.WriteLine($"Health - {Health}");
                            }
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            {
                                y++;
                                Console.SetCursorPosition(Console.BufferWidth - 15, Y);
                                Console.WriteLine(new String(' ', 15));
                                MoveRequest.Invoke(new int[] { x, y }, this);
                                Console.SetCursorPosition(Console.BufferWidth - 15, Y);
                                Console.WriteLine($"Health - {Health}");
                            }
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            {
                                x++;
                                Console.SetCursorPosition(Console.BufferWidth - 15, Y);
                                Console.WriteLine(new String(' ', 15));
                                MoveRequest.Invoke(new int[] { x, y }, this);
                                Console.SetCursorPosition(Console.BufferWidth - 15, Y);
                                Console.WriteLine($"Health - {Health}");
                            }
                            break;
                    }
                }
                if (y != Y && y > 0)
                {
                    Console.SetCursorPosition(Console.BufferWidth - 15, Y);
                    Console.WriteLine(new String(' ', 15));
                }
            }
            
        }
    }
}
