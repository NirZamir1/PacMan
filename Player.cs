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
            Health = 0;
        }
       public override void Do()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write("Pac");
            if (Console.KeyAvailable)
            {
               
                if (Console.ReadKey(true).Key == ConsoleKey.D)
                {
                    _x++;
                }
                else if (Console.ReadKey(true).Key == ConsoleKey.A)
                {
                    _x--;
                }
                else if (Console.ReadKey(true).Key == ConsoleKey.W)
                {
                    _y--;
                }
                else if (Console.ReadKey(true).Key == ConsoleKey.S)
                {
                    _y++;
                }
            }
            Console.SetCursorPosition(_x, _y);
            Console.Write("A");
        }
       
    }
}
