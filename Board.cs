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
            foreach (var item in entities)
            {
                item.MoveRequest += MovePos;
                item.innit();
            }
        }
        public static void Draw(XY pastPos, XY curPos,char Appearnace)
        {
            lock(Locker._Lock)
            {
                Console.SetCursorPosition(pastPos.X, pastPos.Y);
                Console.Write(' ');
                Console.SetCursorPosition(curPos.X, curPos.Y);
                Console.Write(Appearnace);
            }
        }
        public void MovePos(XY WantedPos,IEntity entity)
        {
            var _entities = entities.Where(x => !x.Equals(entity));
            bool All = false;
            if(WantedPos.X >= 0 && WantedPos.Y >= 0 && WantedPos.X <Console.BufferWidth-15)
            {
                foreach (var item in _entities)
                {
                    if(item.Position.X == WantedPos.X && item.Position.Y == WantedPos.Y)
                    {
                        if (item is IEnemy)
                        {
                           entity.Health -= ((IEnemy)item).Damage;
                        }
                        All = true;
                    }
                }
                if (All == false)
                {
                    Draw( entity.Position, WantedPos, entity.Appearnace);
                    entity.Position = WantedPos;
                }
            }
        }
    }
}
