﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public interface IEntity
    {
        void Do(List<IEntity> entities,Board GameBoard);
        int[] GetPosition();
        char GetAppearnace();
    }
}
