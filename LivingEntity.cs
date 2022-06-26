using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public abstract class LivingEntity: IEntity
    {
        protected char Appearnace;
        public int Health { get; set; }
        public virtual int[] Do()
        {
            throw new NotImplementedException();
        }
        public int[] GetPosition { get => new int[] { _x,_y};}
        public char GetAppearnace() => Appearnace;
    }
}
