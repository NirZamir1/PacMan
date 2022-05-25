using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public abstract class LivingEntity: IEntity
    {
        public int _y;
        public int _x;
        protected char Appearnace;
        public int Health { get; set; }
        public virtual void Do(IEntity[] entities,Board GameBoard)
        {
            throw new NotImplementedException();
        }

        public int[] GetPosition()
        {
            return new int[] {_x,_y };
        }
        public char GetAppearnace() => Appearnace;
    }
}
