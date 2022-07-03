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
            Position = new XY(x, y);
            Damage = 5;
            Appearnace = '*';
        }

        public int Damage { get; set; }
        public XY Position { get; set; }
        public int Health { get; set; }
        public char Appearnace { get; set; }

        public event Action<XY, IEntity> MoveRequest;

        public void innit()
        {
            MoveRequest.Invoke(Position, this);
        }
    }
}
