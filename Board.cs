using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Board
    {
        IEntity[] entities;
        public Board(IEntity[] _entities)
        {
            entities = _entities;
            Start();
        }
        private void Start()
        {
            while (true)
            {
                foreach (var entity in entities)
                {
                    entity.Do(entities,this);
                }
            }
        }
        public bool MovePos(int x,int y,IEntity entity)
        {
            //if object can move to ceratin position return true;
            return true;
        }
    }
}
