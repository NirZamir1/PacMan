using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: [bnaya 2022-06-18] think how to encapsulate _x, _y 

namespace PacMan
{
    public abstract class LivingEntity: IEntity
    {
        // TODO: [bnaya 2022-06-18] 
        
        public int _y { get; set; }
        public int _x { get; set; }
        protected char Appearnace;
        public int Health { get; set; }

        // TODO: [bnaya 2022-06-18] if you need to return x,y Array is not the ideal data-type (think of something more restrictive)

        // TODO: [bnaya 2022-06-18] read on abstract (might be better for this method)

        public virtual int[] Do()
        {
            throw new NotImplementedException();
        }

        // TODO: [bnaya 2022-06-18] _x, _y encapsulation this might be a property rather a method
        public int[] GetPosition()
        {
            return new int[] {_x,_y };
        }

        // TODO: [bnaya 2022-06-18] consider using a property
        public char GetAppearnace() => Appearnace;
    }
}
