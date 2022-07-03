using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public interface IEntity
    {
        event Action<XY,IEntity> MoveRequest;
        int Health { get; set; }
        char Appearnace { get; set; }
        void innit();
        public XY Position { get; set; }
    }
    public record XY(int X, int Y);

}
