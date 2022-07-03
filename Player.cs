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
        public int Health { get; set; }
        public XY Position { get; set; }

        public event Action<XY, IEntity> MoveRequest;
        public Player()
        {
            Position = new XY(0,0);
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
                var (x, y) = Position;
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            {
                                lock (Locker._Lock)
                                {
                                    Console.SetCursorPosition(Console.BufferWidth - 15, y);
                                    Console.WriteLine(new String(' ', 15));
                                }
                                x--;
                                MoveRequest.Invoke(new XY( x, y ), this);
                                lock (Locker._Lock)
                                {
                                    Console.SetCursorPosition(Console.BufferWidth - 15, Position.Y);
                                    Console.WriteLine($"Health - {Health}");
                                }
                            }
                            break;
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            {

                                lock (Locker._Lock)
                                {
                                    Console.SetCursorPosition(Console.BufferWidth - 15, y);
                                    Console.WriteLine(new String(' ', 15));
                                }
                                y--;
                                MoveRequest.Invoke(new XY(x, y), this);
                                lock (Locker._Lock)
                                {
                                    Console.SetCursorPosition(Console.BufferWidth - 15, Position.Y);
                                    Console.WriteLine($"Health - {Health}");
                                }
                            }
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            {
                                lock (Locker._Lock)
                                {
                                    Console.SetCursorPosition(Console.BufferWidth - 15, y);
                                    Console.WriteLine(new String(' ', 15));
                                }
                                y++;
                                MoveRequest.Invoke(new XY(x, y), this);
                                lock (Locker._Lock)
                                {
                                    Console.SetCursorPosition(Console.BufferWidth - 15, Position.Y);
                                    Console.WriteLine($"Health - {Health}");
                                }
                            }
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            {
                                x++;
                                lock (Locker._Lock)
                                {
                                    Console.SetCursorPosition(Console.BufferWidth - 15, y);
                                    Console.WriteLine(new String(' ', 15));
                                }
                                x++;
                                MoveRequest.Invoke(new XY(x, y), this);
                                lock (Locker._Lock)
                                {
                                    Console.SetCursorPosition(Console.BufferWidth - 15, Position.Y);
                                    Console.WriteLine($"Health - {Health}");
                                }
                            }
                            break;
                    }
                }
            }
            
        }
    }
}
