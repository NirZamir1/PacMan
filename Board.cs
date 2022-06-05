using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Board
    {
        List<IEntity> entities;
        public Board(IEntity[] _entities)
        {
            entities = _entities.ToList();
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
        public bool MovePos(int x, int y, LivingEntity entity)
        {
            char Appearnace;
            var _entities = entities.Where(x => !x.Equals(entity));
            if (x >= 0 && y >= 0 && x < 225)
            {
                foreach (var item in _entities)
                {
                    if(item.GetPosition()[0] == x && item.GetPosition()[1] == y)
                    {
                        if(item is Wall)
                        {
                            return false;
                        }
                        else if (item is Enemy)
                        {
                            entity.Health -= ((Enemy)item).Damage;
                            return false;
                        }
                    }
                }
                if (x != entity.GetPosition()[0] || y != entity.GetPosition()[1])
                {
                    Console.SetCursorPosition(entity.GetPosition()[0], entity.GetPosition()[1]);
                    Console.Write(' ');
                }
                Appearnace = entity.GetAppearnace();
                Console.SetCursorPosition(x, y);
                Console.Write(Appearnace);
                return true;
            }
            return false;
        }
    }
}
