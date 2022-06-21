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
                var LivingEntities = entities
                    .Where(x => x is LivingEntity)
                    .Select(x => (LivingEntity)x);
                var MoveEntities = LivingEntities
                    .Select(x => (Entity: x, xy: x.Do()))
                    .ToList();
                foreach (var LivingEntity in MoveEntities)
                {
                    if (MovePos(LivingEntity.xy, LivingEntity.Entity, MoveEntities))
                    {
                        int[] pastPos = LivingEntity.Entity.GetPosition;
                        int[] curPos = LivingEntity.xy;
                        char Appearnace = LivingEntity.Entity.GetAppearnace();
                        Draw(pastPos, curPos, Appearnace);
                        LivingEntity.Entity._x = LivingEntity.xy[0];
                        LivingEntity.Entity._y = LivingEntity.xy[1];
                    }
                }
            }
        }
        public void Draw(int[] pastPos, int[] curPos,char Appearnace)
        {
            Console.SetCursorPosition(pastPos[0], pastPos[1]);
            Console.Write(' ');
            Console.SetCursorPosition(curPos[0], curPos[1]);
            Console.Write(Appearnace);  
        }
        public bool MovePos(int[] xy, LivingEntity entity,IEnumerable<(LivingEntity Entity,int[] xy)> MoveList)
        {
            var _entities = MoveList.Where(x => !x.Entity.Equals(entity));
            if(xy[0] >= 0 && xy[1] >= 0 && xy[0] <Console.BufferWidth-15)
            {
                foreach (var item in _entities)
                {
                    if(item.xy[0] == xy[0] && item.xy[1] == xy[1])
                    {
                        if(item.Entity is Wall)
                        {
                            return false;
                        }
                        else if (item.Entity is Enemy )
                        {
                            entity.Health -= ((Enemy)item.Entity).Damage;
                            return false;
                        }
                        return false;
                    }
                }
                /*if (xy[0] != entity.GetPosition()[0] || xy[1] != entity.GetPosition()[1])
                {
                    Console.SetCursorPosition(entity.GetPosition()[0], entity.GetPosition()[1]);
                    Console.Write(' ');
                }
                Appearnace = entity.GetAppearnace();
                Console.SetCursorPosition(xy[0], xy[1]);
                Console.Write(Appearnace);
                
                entity._x= xy[0];
                entity._y= xy[1];
                */
                return true;
            }
            return false;
        }
    }
}
