using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Spike : Enemy
    {
        public Spike(int x,int y)
        {
            _x = x;
            _y = y;
            Damage = 5;
            Appearnace = '*';
        }
        public override int[] Do()
        {
            return new int[] { _x, _y };
        }
    }
}
