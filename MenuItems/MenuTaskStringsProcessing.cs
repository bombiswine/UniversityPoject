using System;
using System.Text.RegularExpressions;

namespace TrainingMenu.MenuItems
{
    class MenuTaskStringsProcessing : MenuTaskCore
    {
        public override string Title { get { return "Strings Processing"; } }

        public override void Execute()
        {
            string firstStr = IOUtils.SafeReadString("Please, enter the first string: ");
            try
            {
                WhatThisStringIs(firstStr);
            }
            catch(ValidationException validEx)
            {
                Console.WriteLine("[Validation Exception] " + validEx.Message);
            }
            
            string secondStr = IOUtils.SafeReadString("Please, enter the second string: ");
            try
            {
                WhatThisStringIs(secondStr);
            }
            catch (ValidationException validEx)
            {
                Console.WriteLine("[Validation Exception] " + validEx.Message);
            }
            
            CompareStrings(firstStr, secondStr);
        }

        public static string ReverseString(string str)
        {
            char[] strArr = str.ToCharArray();
            Array.Reverse(strArr);

            return new string(strArr);
        }

        public static void WhatThisStringIs(string str)
        {
            if (IsEmail(str))
            {
                Console.WriteLine("This string is the email");
            }
            else if (IsIP(str))
            {
                Console.WriteLine("This string is the IP");
            }
            else if (IsPhoneNumber(str))
            {
                Console.WriteLine("This string is the phone number");
            }
            else
            {
                throw new ValidationException("This string is neither email nor phone number, nor IP-address");
            }
        }

        public static void CompareStrings(string firstStr, string secondStr)
        {
            try
            {
                AreEquals(firstStr, secondStr);
            } 
            catch(ValidationException validEx)
            {
                Console.WriteLine("[Validation Exception] " + validEx.Message);
            }

            try
            {
                AreEqualsAfterModifying(firstStr, secondStr);
            }
            catch (ValidationException validEx)
            {
                Console.WriteLine("[Validation Exception] " + validEx.Message);
            }

            try
            {
                AreEachOtherReflections(firstStr, secondStr);
            }
            catch (ValidationException validEx)
            {
                Console.WriteLine("[Validation Exception] " + validEx.Message);
            }
        }

        public static void AreEquals(string firstStr, string secondStr)
        {
            if (!string.Equals(firstStr, secondStr))
            {
                throw new ValidationException("Input strings aren't equals");
            }

            Console.WriteLine("Input strings are equals");
        }

        public static void AreEqualsAfterModifying(string firstStr, string secondStr)
        {
            Regex trimmer = new Regex(@"\s\s+");
            firstStr  = trimmer.Replace(firstStr, " ").Trim().ToLower();
            secondStr = trimmer.Replace(secondStr, " ").Trim().ToLower();

            if (!string.Equals(firstStr, secondStr))
            {
                throw new ValidationException("Input strings aren't equals after converting to one case and removing extra spaces");
            }

            Console.WriteLine("Input strings are equals after converting to one case and removing extra spaces");
        }

        public static void AreEachOtherReflections(string firstStr, string secondStr)
        {
            if (!string.Equals(firstStr, ReverseString(secondStr)))
            {
                throw new ValidationException("Input strings aren't reflections of each other");
            }

            Console.WriteLine("Input strings are reflections of each other");
        }

        public static bool IsEmail(string str)
        {
            const string emailRegex = @"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+";

            return Regex.IsMatch(str, emailRegex);
        }

        public static bool IsPhoneNumber(string str)
        {
            const string phoneNumberRegex = @"^[\+]?[0-9][(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{2}[-\s\.]?[0-9]{2}$";

            return Regex.IsMatch(str, phoneNumberRegex);
        }

        public static bool IsIP(string str)
        {
            const string IPRegex = @"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}";

            return Regex.IsMatch(str, IPRegex);
        }
    }
}
