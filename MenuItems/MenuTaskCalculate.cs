using System;

namespace TrainingMenu.MenuItems
{
    public class MenuTaskCalculate : MenuTaskCore
    {
        public override string Title { get { return "Calculate: (Y - sqrt(X)) / Z"; } }

        public override void Execute()
        {
            int iNumberX = IOUtils.SafeReadPositiveInteger("Enter X: ");
            int iNumberY = IOUtils.SafeReadInteger("Enter Y: ");
            int iNumberZ = IOUtils.SafeReadNotNullInteger("Enter Z: ");

            string sCalculationResult = CalculateTheFormula(iNumberX, iNumberY, iNumberZ).ToString("F3");

            Console.WriteLine($"The result of calculations is: {sCalculationResult}");
        }

        public static double CalculateTheFormula(int iX, int iY, int iZ)
        {
            return (iY - Math.Sqrt(iX)) / iZ;
        }
    }
}
