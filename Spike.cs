using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Spike : IEnemy
    {
        public Spike(int x,int y)
        {
            X = x;
            Y = y;
            Damage = 5;
            Appearnace = '*';
        }

        public int Damage { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Health { get; set; }
        public char Appearnace { get; set; }

        public event Action<int[], IEntity> MoveRequest;

        public void innit()
        {
            MoveRequest.Invoke(new int[] { X, Y }, this);
        }
    }
}
