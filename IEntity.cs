using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public interface IEntity
    {
        int _y {protected get; set; }
        int _x {protected get; set; }
        int[] GetPososition { get=> new int[] {_x,_y};}
        int[] Do();
        char GetAppearnace();
    }
}
