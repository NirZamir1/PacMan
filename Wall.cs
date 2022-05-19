using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Wall : LivingEntity
    {
        public Wall(int x, int y)
        {
            _x = x;
            _y = y;
            Console.SetCursorPosition(_y, _x);
            Console.Write('/');
        }
        public override void Do(IEntity[] entities)
        {
        }
    }
}
