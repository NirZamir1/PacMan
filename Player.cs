using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public sealed class Player : LivingEntity
    {
        public Player()
        {
            _x = 0;
            _y = 0;
            Health = 10;
            Appearnace = 'A';
        }
        public override int[] Do()
        {
            int x = _x;
            int y = _y;
            Console.SetCursorPosition(Console.BufferWidth - 15, y);
            Console.WriteLine($"Health - {Health}");
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A:
                        x--;
                        break;
                    case ConsoleKey.W:
                        y--;
                        break;
                    case ConsoleKey.S:
                        y++;
                        break;
                    case ConsoleKey.D:
                        x++;
                        break;
                }
            }
            if(y != _y && y > 0)
            {
                Console.SetCursorPosition(Console.BufferWidth-15, _y);
                Console.WriteLine(new String(' ',15));
            }
            return new[] { x, y };
            
        }
    }
}
