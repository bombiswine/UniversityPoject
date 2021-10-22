using System;
using TrainingMenu.SpecialTypes;

namespace TrainingMenu.MenuItems
{
    class MenuTaskAckermannFunction : MenuTaskCore
    {
        public override string Title { get { return "Calculation of Ackermann's function"; } }

        public override void Execute()
        {
            const int cMaxMeaningParameterM = 3;

            DaysRange oFirstRange = new DaysRange("Enter the first day range");
            DaysRange oSecondRange = new DaysRange("Enter the second day range");

            int iParameterM = DaysRange.CountDaysInIntersectionOf(oFirstRange, oSecondRange);

            if (iParameterM > cMaxMeaningParameterM)
            {
                Console.WriteLine("Sorry, cannot be calculated: tha range length is too big");
                return;
            }
            else
            {
                int iCalculatioResult = AckermannFunction(iParameterM);
                Console.WriteLine($"The result is: {iCalculatioResult}");
            }
        }
        private int AckermannFunction(int iParamM, int iParamN = 5)
        {
            int iResult = 0;

            if (iParamM == 0)
            {
                iResult =  iParamN + 1;
            }
            else if (iParamM > 0 && iParamN == 0)
            {
                return AckermannFunction(iParamM - 1, 1);
            }
            else if (iParamM > 0 && iParamN > 0)
            {
                return AckermannFunction(iParamM - 1, AckermannFunction(iParamM, iParamN - 1));
            }

            return iResult;
        }
    }
}
