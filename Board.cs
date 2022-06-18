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
                /*
                 foreach (var entity in entities)
                 {
                    if (entity is LivingEntity)
                     {
                        var xy = entity.Do();
                        if (MovePos(xy,(LivingEntity)entity))
                             isChanged = true;
                     }

                 }
                 if (isChanged)
                */
                var LivingEntities = entities.Where(x => x is LivingEntity).Select(x => (LivingEntity)x);
                var MoveEntities = LivingEntities
                                // TODO: [bnaya 2022-06-18] it show you got the idea of LINQ, yet as most of us do when discover a new tech, we use it too much. think whether it won't be easier to understanding if you would go in within the foreach (maybe encapsulate it in a class or method)
                                .Select(x => (Entity: x, xy: x.Do()))
                                .Where(x => !x.xy.Equals(x.Entity.GetPosition()))
                                .Where(x => MovePos(x.xy,x.Entity));
                foreach (var LivingEntity in MoveEntities)
                {
                    // TODO: [bnaya 2022-06-18] don't call methods inside the Draw function (it's hard to debug and less clear), call it befor the method & hold return value inside a variable
                    Draw(LivingEntity.Entity.GetPosition(), LivingEntity.xy, LivingEntity.Entity.GetAppearnace());

                    LivingEntity.Entity._x = LivingEntity.xy[0];
                    LivingEntity.Entity._y = LivingEntity.xy[1];
                }
            }
        }
        public void Draw(int[] pastPos, int[] curPos,char Appearnace)
        {
            // TODO: [bnaya 2022-06-18] what will happens if me = 'A' & enemy = 'E' change positions? befor state is 'AE' after everyone moves it should look like 'EA', I don't sure this logic will do it correct without deleting either 'A' or 'E'. Think of it & come with a simple solution of not deleting anything when trying to clear previous position 
            Console.SetCursorPosition(pastPos[0], pastPos[1]);
            Console.Write(' ');
            Console.SetCursorPosition(curPos[0], curPos[1]);
            Console.Write(Appearnace);
            // doesn't work with console.clear();

            /*
            Console.Clear();
            foreach (var item in entities)
            {
                Console.SetCursorPosition(item.GetPosition()[0], item.GetPosition()[1]);
                Console.Write(item.GetAppearnace());
            }
            */
        }

        public bool MovePos(int[] xy, LivingEntity entity)
        {
            var _entities = entities.Where(x => !x.Equals(entity));
            if (xy[0] >= 0 && xy[1] >= 0 && xy[0] <Console.BufferWidth-15)
            {
                foreach (var item in _entities)
                {
                    if(item.GetPosition()[0] == xy[0] && item.GetPosition()[1] == xy[1])
                    {
                        // remark: [bnaya 2022-06-18] nice use of pattern matching
                        // TODO: [bnaya 2022-06-18] think of edge cases, like me & my enemy moving to each other positions, this algorithm might miss it depending the location in the entities array (locale before or after the enemy) 
                        if (item is Wall)
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
