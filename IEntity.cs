﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public interface IEntity
    {
        int[] Do();
        int[] GetPosition();
        char GetAppearnace();
    }
}
