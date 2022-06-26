using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public record XY(int X, int Y);
    
    public interface IEntity
    {
       
        XY Position { get; set; }
        char GetAppearnace();
        event Action<int[],IEntity> MoveRequest;
    }
    
}
