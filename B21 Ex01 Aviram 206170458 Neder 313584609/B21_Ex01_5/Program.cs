using System;

namespace B21_Ex01_5
{
    public class Program
    {
        const int k_numberOfDigits = 6;
        public static void Main(string[] args)
        {
            initiateProgram();
        }

        private static void initiateProgram()
        {
            int sixDigitNaturalNumber = int.Parse(readValidInput());
            printStatistics(sixDigitNaturalNumber);   
        }

        private static string readValidInput()
        {
            Console.WriteLine("Please enter a natural number of {0} digits:", k_numberOfDigits);
            string o_input = Console.ReadLine();
            while (!isValidInput(o_input))
            {
                Console.WriteLine("Invalid input. Please re-enter a natural number of {0} digits:", k_numberOfDigits);
                o_input = Console.ReadLine();
            }
            return o_input;
        }

        private static bool isValidInput(string i_inputNum)
        {
            bool o_isValidInput = isOfProperLength(i_inputNum) && isNaturalNumberStr(i_inputNum);
            return o_isValidInput;
        }

        private static bool isOfProperLength(string i_inputNum)
        {
            bool o_isOfProperLength = i_inputNum.Length == k_numberOfDigits;
            return o_isOfProperLength;
        }

        private static bool isNaturalNumberStr(string i_inputNum)
        {
            bool o_isNaturalNumberStr = int.TryParse(i_inputNum, out int parseResult) && parseResult > 0;
            return o_isNaturalNumberStr;
        }

        private static void printStatistics(int i_inputNum)
        {
            Console.WriteLine("Printing statistics about the number {0}", i_inputNum);
            printMaxAndMinDigit(i_inputNum);
            printHowManyDivByThree(i_inputNum);
            printHowManyGreaterThanUnitsDigit(i_inputNum);
        }

        private static void printMaxAndMinDigit(int i_inputNum)
        {
            int maxDigit = i_inputNum % 10;
            int minDigit = i_inputNum % 10;
            while(i_inputNum > 0)
            {
                if(i_inputNum % 10 > maxDigit)
                {
                    maxDigit = i_inputNum % 10;
                }
                else if (i_inputNum % 10 < minDigit)
                {
                    minDigit = i_inputNum % 10;
                }
                i_inputNum /= 10;
            }
            Console.WriteLine("The greatest digit of the number is {0}", maxDigit);
            Console.WriteLine("The least great digit of the number is {0}", minDigit);
        }

        private static void printHowManyDivByThree(int i_inputNum)
        {
            int divByThreeCounter = countHowManyDivByThree(i_inputNum);
            Console.WriteLine("There are {0} digits who are dividable by three.", divByThreeCounter);
        }

        private static int countHowManyDivByThree(int i_inputNum)
        {
            int o_divByThreeCounter = 0;
            while(i_inputNum > 0)
            {
                if(isDivByThree(i_inputNum % 10))
                {
                    o_divByThreeCounter++;
                }
                i_inputNum /= 10;
            }
            return o_divByThreeCounter;
        }

        private static bool isDivByThree(int i_inputNum)
        {
            bool o_isDivByThree = i_inputNum % 3 == 0;
            return o_isDivByThree;
        }

        private static void printHowManyGreaterThanUnitsDigit(int i_inputNum)
        {
            int greaterCounter = countHowManyGreaterThanUnitsDigit(i_inputNum);
            Console.WriteLine("There are {0} digits who are greater than the digit of units.", greaterCounter);
        }

        private static int countHowManyGreaterThanUnitsDigit(int i_inputNum)
        {
            int o_greaterCounter = 0; // Counts how many digits are greater than the digit of units.
            int unitsDigit = i_inputNum % 10;
            int currentUnitsDigit;
            while(i_inputNum > 0)
            {
                currentUnitsDigit = i_inputNum % 10;
                if (currentUnitsDigit > unitsDigit)
                {
                    o_greaterCounter++;
                }
                i_inputNum /= 10;
            } 
            return o_greaterCounter;
        }


    }
}
