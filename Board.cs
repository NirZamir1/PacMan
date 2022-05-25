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
        public bool MovePos(int x, int y, IEntity entity)
        {
            char Appearnace;
            var _entities = entities.Where(x => !x.Equals(entity));
            if (_entities.Any(_entity => (_entity.GetPosition()[0] != x) || (_entity.GetPosition()[1] != y)))
            {
               Appearnace = entity.GetAppearnace();
               Console.SetCursorPosition(x, y);
               Console.Write(Appearnace);
               return true;
            }
            return false;
        }
    }
}
