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
            Appearnace = 'A';
        }
       public override void Do(IEntity[] entities,Board GameBoard)
       {
            int x = _x;
            int y = _y;
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
            if(GameBoard.MovePos(x,y,this))
            {
                Console.SetCursorPosition(_x, _y);
                Console.Write(' ');
                _x = x;
                _y = y;
                Console.SetCursorPosition(_x, _y);
                Console.Write(Appearnace);
            }
        }
    }
}
