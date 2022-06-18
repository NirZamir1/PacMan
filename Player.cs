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
            // TODO: [bnaya 2022-06-18] 
            int x = _x;
            int y = _y;
            Console.SetCursorPosition(Console.BufferWidth-15, y);
            Console.WriteLine($"Health - {Health}");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    x--;
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    y--;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    y++;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    x++;
                    break;
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
