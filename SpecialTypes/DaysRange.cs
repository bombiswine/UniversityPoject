using System;

namespace TrainingMenu.SpecialTypes
{
    public class DaysRange
    {
        public DateTime Begining { get; set; }
        public DateTime Ending { get; set; }

        public DaysRange()
        { }

        public DaysRange(DateTime beginingDate, DateTime endingDate)
        {
            if (beginingDate <= endingDate)
            {
                Begining = beginingDate;
                Ending = endingDate;
            }
            else
            {
                throw new ValidationException("Invalid days range");
            }
        }

        public DaysRange(string message = null)
        {
            Console.WriteLine(message);

            while (true)
            {
                Begining = IOUtils.SafeReadDate("Begining date: ");
                Ending = IOUtils.SafeReadDate("Ending date: ");

                if (Begining > Ending)
                {
                    Console.WriteLine("Error: invalid day range\nRepeat the input");
                }
                else break;
            }
        }

        public int Length
        {
            get
            {
                return (Ending - Begining).Days + 1;
            }
        }

        public static int CountDaysInIntersectionOf(DaysRange ThisRange, DaysRange AnotherRange)
        {
            int intersectionLength = 0;

            if(!(ThisRange.Begining > AnotherRange.Ending || ThisRange.Ending < AnotherRange.Begining))
            {
                DaysRange rangesIntersection = new DaysRange();
                rangesIntersection.Begining = (ThisRange.Begining > AnotherRange.Begining) ? ThisRange.Begining : AnotherRange.Begining;
                rangesIntersection.Ending = (ThisRange.Ending < AnotherRange.Ending) ? ThisRange.Ending : AnotherRange.Ending;
                
                intersectionLength = rangesIntersection.Length;
            }

            return intersectionLength;
        }
    }
}
