using System;

namespace EX01
{
    public class Program4
    {
        const int k_lengthOfInput = 10;
        public static void Main()
        {
            initiateProgram();
        }

        private static void initiateProgram()
        {
            string validString = readValidString(); // Reads a string of length 10 and validates its format
            printStringAnalysis(validString);
        }

        private static string readValidString()
        {
            Console.WriteLine("Please enter a {0} length string that contains only digits or only letters, and press enter ", k_lengthOfInput);
            string o_validStr = Console.ReadLine();
            while (!isValid(o_validStr)) // Keep reading inputs from the user untill you get a valid input.
            {
                Console.WriteLine("The input was invalid. Please re-enter a {0}-length string that contains only digits or only letters and press ENTER", k_lengthOfInput);
                o_validStr = Console.ReadLine();
            }
            return o_validStr;
        }

        private static bool isValid(string i_validetStr)
        {
            // Checks if the stirng is of valid length and either digits only or letters only.
            bool o_isValid = isOfProperLength(i_validetStr) && (isNumStr(i_validetStr) || isALetterStr(i_validetStr));
            return o_isValid;
        }

        private static bool isOfProperLength(string i_validetStr)
        {
            bool o_isOfPrperLength = i_validetStr.Length == k_lengthOfInput;
            return o_isOfPrperLength;
        }

        private static bool isNumStr(string i_validStr)
        {
            bool o_isANum = true;
            for (int i = 0; i < i_validStr.Length; i++)
            {
                if (!char.IsDigit(i_validStr[i])) // If there's a character which is not a digit, returns false.
                {
                    o_isANum = false;
                    break;
                }
            }
            return o_isANum;
        }

        private static bool isALetterStr(string i_validetStr)
        {
            bool o_isALetterStr = true;
            for (int i = 0; i < i_validetStr.Length; i++)
            {
                if (!char.IsLetter(i_validetStr[i])) // If there's a character which is not a letter, returns false.
                {
                    o_isALetterStr = false;
                    break;
                }
            }
            return o_isALetterStr;
        }

        private static void printStringAnalysis(string i_validStr)
        {
            printIsItAPalindrom(i_validStr);
            bool isADigitStr = isNumStr(i_validStr);
            printDivInFourOrNumOfCapital(i_validStr); // If the input is a number prints if its dividable by 4. If it's a string of letters prints the number of capitals in the string.
        }

        private static void printIsItAPalindrom(string i_aValidStr)
        {
            bool isAPal = isAPalindrom(i_aValidStr); // Checks if the string is a palindrom.
            if (isAPal)
            {
                Console.WriteLine("The input is a palindrom");
            }
            else
            {
                Console.WriteLine("The input is not a palindrom");
            }
        }

        private static bool isAPalindrom(string i_aValidStr)
        {
            bool o_isAPal;
            if(i_aValidStr.Length == 1)     // A string of length 1 is a palindrom.
            {
                o_isAPal = true;
            }
            else if(i_aValidStr[0] != i_aValidStr[i_aValidStr.Length - 1])  // If letters of the opposite index are different, it is not a palindrom.
            {
                o_isAPal = false;
            }
            else if(i_aValidStr.Length == 2) // A string of length 2 with both letters the same is a palindrom.
            {
                o_isAPal = true;
            }
            else
            {
                o_isAPal = isAPalindrom(i_aValidStr.Substring(1, i_aValidStr.Length - 2));  // The two extreme letters are the same. Check if the string trimmed by 1 (from each edge) is also a palindrom.
            }
            return o_isAPal;
        }

        private static void printDivInFourOrNumOfCapital(string i_validStr)
        {
            if (isNumStr(i_validStr))
            {
                printIsDivByFour(i_validStr);
            }
            else
            {
                printNumOfCapital(i_validStr);
            }
        }

        private static void printIsDivByFour(string i_validNumStr)
        {
            ulong convertedToNum = ulong.Parse(i_validNumStr);
            bool isDivByFour = isDividableByFour(convertedToNum);
            if (isDivByFour)
            {
                Console.WriteLine("The number is dividable by 4");
            }
            else
            {
                Console.WriteLine("The number is not dividable by 4");
            }
        }

        private static bool isDividableByFour(ulong i_convertedToNum)
        {
            bool o_isDivByFour = i_convertedToNum % 4 == 0;
            return o_isDivByFour;
        }

        private static void printNumOfCapital(string i_validStr)
        {
            int capitalCounter = countCapitals(i_validStr);

            Console.WriteLine("The number of capital letters in the input is {0}", capitalCounter);

        }

        private static int countCapitals(string i_validStr)
        {
            int o_numOfCapital = 0;
            for (int i = 0; i < i_validStr.Length; i++)
            {
                if (char.IsUpper(i_validStr[i]))
                {
                    o_numOfCapital++;
                }
            }
            return o_numOfCapital;
        }

    }

}
