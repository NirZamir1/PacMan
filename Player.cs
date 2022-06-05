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
       public override void Do(List<IEntity> entities,Board GameBoard)
       {
            int x = _x;
            int y = _y;
            Console.SetCursorPosition(Console.BufferWidth-15, y);
            Console.WriteLine($"Health - {Health}");
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
                Console.SetCursorPosition(Console.BufferWidth - 15,_y);
                Console.Write(new String(' ',15));
                _x = x;
                _y = y;
            }
            
        }
    }
}
