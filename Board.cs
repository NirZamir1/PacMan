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
                    if (entity is LivingEntity)
                    {
                        MovePos(entity.Do(),(LivingEntity)entity);
                    }
                }
            }
        }
        public bool MovePos(int[] xy, LivingEntity entity)
        {
            char Appearnace;
            var _entities = entities.Where(x => !x.Equals(entity));
            if (xy[0] >= 0 && xy[1] >= 0 && xy[0] <Console.BufferWidth-15)
            {
                foreach (var item in _entities)
                {
                    if(item.GetPosition()[0] == xy[0] && item.GetPosition()[1] == xy[1])
                    {
                        if(item is Wall)
                        {
                            return false;
                        }
                        else if (item is Enemy )
                        {
                            entity.Health -= ((Enemy)item).Damage;
                            return false;
                        }
                    }
                }
                if (xy[0] != entity.GetPosition()[0] || xy[1] != entity.GetPosition()[1])
                {
                    Console.SetCursorPosition(entity.GetPosition()[0], entity.GetPosition()[1]);
                    Console.Write(' ');
                }
                Appearnace = entity.GetAppearnace();
                Console.SetCursorPosition(xy[0], xy[1]);
                Console.Write(Appearnace);
                entity._x= xy[0];
                entity._y= xy[1];
                return true;
            }
            return false;
        }
    }
}
