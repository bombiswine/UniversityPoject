using System;

namespace TrainingMenu.MenuItems
{
    class MenuTaskCalculate : MenuTaskCore
    {
        public override string Title { get { return "Calculate: (Y - sqrt(X)) / Z"; } }

        public override void Execute()
        {
            int iNumberX;
            int iNumberY;
            int iNumberZ;

            while (true)
            {
                iNumberX = IOUtils.SafeReadInteger("Enter the X: ");
                if (iNumberX < 0)
                {
                    Console.Write("Input error: X must be positive\nRepeat the input");
                }
                else
                {
                    break;
                }
            }

            iNumberY = IOUtils.SafeReadInteger("Enter the Y: ");

            while (true)
            {
                iNumberZ = IOUtils.SafeReadInteger("Enter the Z: ");
                if (iNumberZ == 0)
                {
                    Console.WriteLine("Input error: Z must not be zero\nRepeat the input");
                }
                else 
                { 
                    break;
                }
            }

            string sCalculationResult = ((iNumberY - Math.Sqrt(iNumberX)) / iNumberZ).ToString("F3");

            Console.WriteLine($"The result of calculations is: {sCalculationResult}");
        }
    }
}
