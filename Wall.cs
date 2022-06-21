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
            Appearnace = '/';
        }
        public override int[] Do( )
        {
            return new int[] { _x, _y };
        }
    }
}
