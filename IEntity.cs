using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public interface IEntity
    {
        int X { get; set; }
        int Y { get; set; }
        event Action<int[],IEntity> MoveRequest;
        int Health { get; set; }
        char Appearnace { get; set; }
        void innit();
    }

}
