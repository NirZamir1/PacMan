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
        public static void Draw(int[] pastPos, int[] curPos,char Appearnace)
        {
            Console.SetCursorPosition(pastPos[0], pastPos[1]);
            Console.Write(' ');
            Console.SetCursorPosition(curPos[0], curPos[1]);
            Console.Write(Appearnace);  
        }
        public void MovePos(int[] WantedPos,IEntity entity)
        {
            var _entities = entities.Where(x => !x.Equals(entity));
            bool All = false;
            if(WantedPos[0] >= 0 && WantedPos[1] >= 0 && WantedPos[0] <Console.BufferWidth-15)
            {
                foreach (var item in _entities)
                {
                    if(item.X == WantedPos[0] && item.Y == WantedPos[1])
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
                    Draw(new int[] { entity.X, entity.Y }, WantedPos, entity.Appearnace);
                    entity.X = WantedPos[0];
                    entity.Y = WantedPos[1];
                }
            }
        }
    }
}
