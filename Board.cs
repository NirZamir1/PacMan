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
        }
        public void Start()
        {
            while (true)
            {
                foreach (var entity in entities)
                {
                    entity.Do(entities);
                }
            }
        }
    }
}
