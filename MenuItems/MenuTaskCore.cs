﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingMenu.MenuItems
{
    abstract class MenuTaskCore
    {
        public abstract string Title { get; }
        public abstract void   Execute();
    }
}
