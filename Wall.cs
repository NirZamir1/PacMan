using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Wall : IEntity
    {
        public Wall(int x, int y)
        {
            Position = new XY(x, y);
            Appearnace = '/';
        }

        

        public void innit()
        {
            MoveRequest.Invoke(Position, this);
        }
       
        public int Health { get; set; }
        public char Appearnace { get; set; }
        public XY Position { get; set; }

        public event Action<XY, IEntity> MoveRequest;
    }
}
