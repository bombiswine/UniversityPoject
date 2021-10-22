using System;

namespace TrainingMenu
{
    public class IOUtils
    {
        public static int SafeReadInteger(string message = null)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.Write(message);
            }

            string sInput;
            int    iParsedInput;

            while (true)
            {
                sInput = Console.ReadLine();
                bool bIsValidInteger = int.TryParse(sInput, out iParsedInput);

                if (!bIsValidInteger)
                {
                    Console.WriteLine("Error: input value must be integer");
                    Console.Write(message);
                }
                else
                {
                    return iParsedInput;
                }
            }
        }

        public static DateTime SafeReadDate(string message = null)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.Write(message);
            }

            DateTime date;

            while (true)
            {
                string sUserInput = Console.ReadLine();
                bool   bIsValidDate = DateTime.TryParseExact(sUserInput, format: "dd.MM.yyyy",
                                                             System.Globalization.CultureInfo.InvariantCulture, 
                                                             System.Globalization.DateTimeStyles.None, 
                                                             out date);
                if (!bIsValidDate)
                {
                    Console.WriteLine("Error: input must be date in the format dd.mm.yyyy");
                    Console.Write(message);
                }
                else
                {
                    return date;
                }
            }
        }

        public static string SafeReadString(string message = null)
        {
            if (message != null)
            {
                Console.Write(message);
            }

            return Console.ReadLine();
        }
    }
}