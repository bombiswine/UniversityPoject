namespace TrainingMenu.MenuItems
{
    public abstract class MenuTaskCore
    {
        public abstract string Title { get; }
        public abstract void   Execute();
    }
}
