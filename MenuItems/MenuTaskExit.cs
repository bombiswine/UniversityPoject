using System;

namespace TrainingMenu.MenuItems
{
    public class MenuTaskExit : MenuTaskCore
    {
        public override string Title { get { return "Exit"; } }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
