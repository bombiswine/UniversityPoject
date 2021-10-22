﻿using System;

namespace TrainingMenu.MenuItems
{
    class MenuTaskHelloWorld : MenuTaskCore
    {
        public override string Title { get { return "Hello World"; } }

        public override void Execute()
        {
            Console.WriteLine("Hello world");
        }
    }
}
