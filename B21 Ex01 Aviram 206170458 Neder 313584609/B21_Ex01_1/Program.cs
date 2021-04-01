using System;

namespace Ex01
{
    /**
     * Notes:   We have to implement isAscendingSeries.
     *          We should check textual edge cases (like there are 1 numbers instead of there is one number).
     *          Also, think about export statistics functions to another class(?)
     *          Let Itamar go over our code :P
     */
    public class Program
    {
        const int k_lengthOfInput = 7;
        const int k_numOfInput = 3;
        public static void Main()
        {
            initiateProgram();
        }

        private static void initiateProgram()
        {
            string[] BinaryStrNumArray = ReadBinaryNumsArray(); //Reads binary numbers as strings and validates their format, 
            int[] binaryConvertedToDecimalArray = ConvertToDecimalArray(BinaryStrNumArray); //converts all binary strings to decimal numbers.
            PrintDecimalArray(binaryConvertedToDecimalArray); //Prints the array of decimal numbers
            PrintStatistics(BinaryStrNumArray, binaryConvertedToDecimalArray);

            Console.ReadLine();
            
        }

        private static void PrintDecimalArray(int[] binaryConvertedToDecimalArray)
        {
            Console.WriteLine("The decimal representation of the inputs are (respectively):");
            for (int i = 0; i < k_numOfInput; i++)
            {
                Console.WriteLine(@"{0:F}", binaryConvertedToDecimalArray[i]);
            }
        }

        private static int[] ConvertToDecimalArray(string[] i_BinaryStrNumArray)
        {
            int[] binaryConvertedToDecmial = new int[k_numOfInput];
            for (int i = 0; i < k_numOfInput; i++)
            {
                binaryConvertedToDecmial[i] = ConvertBinaryStrToDecimal(i_BinaryStrNumArray[i]);
            }
            return binaryConvertedToDecmial;
        }

        private static int ConvertBinaryStrToDecimal(string i_BinaryStr)
        {
            int decimalNum = 0;
            int binaryNum = int.Parse(i_BinaryStr);

            for (int i = 0; i < i_BinaryStr.Length; i++)
            {
                int leastSignificantDigit = binaryNum % 10;
                decimalNum += (int)Math.Pow(2, i) * leastSignificantDigit;
                binaryNum /= 10;
            }
            return decimalNum;
        }

        private static string[] ReadBinaryNumsArray()
        {
            string[] binaryNumbersArray = new string[k_numOfInput];
            for (int i = 0; i < k_numOfInput; i++)
            {
                binaryNumbersArray[i] = ReadBinaryNum();
            }
            return binaryNumbersArray;
        }

        private static string ReadBinaryNum()
        {
            Console.WriteLine(
 @"Please enter a {0}-digit binary format number
and press enter ", k_lengthOfInput);
            string BinaryNumberStr = Console.ReadLine();
            while (!isValid(BinaryNumberStr))
            {
                Console.WriteLine(
 @"The input was invalid.
Please re-enter a {0}-digit binary format number
and press enter ", k_lengthOfInput);
                BinaryNumberStr = Console.ReadLine();
            };
            return BinaryNumberStr;
        }

        private static bool isValid(string i_BinaryStr)
        {
            bool isValid = false;
            if (i_BinaryStr.Length == k_lengthOfInput && isBinary(i_BinaryStr))
            {
                isValid = true;
            }
            return isValid;
        }

        private static bool isBinary(string i_BinaryStr)
        {
            bool isBinary = true;
            for (int i = 0; i < i_BinaryStr.Length; i++)
                if (!i_BinaryStr[i].Equals('0') && !i_BinaryStr[i].Equals('1'))
                {
                    isBinary = false;
                    break;
                }
            return isBinary;
        }

        private static void PrintStatistics(string[] i_binaryStrNumArray, int[] i_binaryConvertedToDecimalArray)
        {
            PrintAverageZeros(i_binaryStrNumArray);
            PrintAverageOnes(i_binaryStrNumArray);
            PrintPowerofTwo(i_binaryConvertedToDecimalArray);
            PrintAscendingSeriesofDigits(i_binaryConvertedToDecimalArray);
            PrintMinAndMaxNum(i_binaryConvertedToDecimalArray);
        }

        private static void PrintMinAndMaxNum(int[] i_binaryConvertedToDecimalArray)
        {
            int minNumIndex = 0;
            int maxNumIndex = 0;
            for (int i = 0; i < i_binaryConvertedToDecimalArray.Length; i++)
            {
                if (i_binaryConvertedToDecimalArray[i] < i_binaryConvertedToDecimalArray[minNumIndex])
                {
                    minNumIndex = i;
                } else if (i_binaryConvertedToDecimalArray[i] > i_binaryConvertedToDecimalArray[maxNumIndex])
                {
                    maxNumIndex = i;
                }
            }
            Console.WriteLine("The minimal number in the array is {0}", i_binaryConvertedToDecimalArray[minNumIndex]);
            Console.WriteLine("The maximal number in the array is {0}", i_binaryConvertedToDecimalArray[maxNumIndex]);
        }

        private static void PrintAscendingSeriesofDigits(int[] i_binaryConvertedToDecimalArray)
        {
            int counterOfAscendingSeriesNumbers = 0;
            for (int i = 0; i < i_binaryConvertedToDecimalArray.Length; i++)
            {
                if (isAscendingSeries(i_binaryConvertedToDecimalArray[i]))
                {
                    counterOfAscendingSeriesNumbers++;
                }
            }
            Console.WriteLine("there are {0} inputs whos decimal representation is an ascending order", counterOfAscendingSeriesNumbers);
        }

        private static bool isAscendingSeries(int i_binaryNumConvertedToDecimal)
        {
            bool isAscedingSeries = true;
            // Implementing with a string seems easier, as using numbers will require logs and stuff.
            // But with Guy you never know what he expects.
            // Do what you think :)
            return isAscedingSeries;
        }

        private static void PrintPowerofTwo(int[] i_binaryConvertedToDecimalArray)
        {
            int counterOfPowerOfTwo = 0;
            for (int i = 0; i < i_binaryConvertedToDecimalArray.Length; i++)
            {
                if(isPowerOfTwo(i_binaryConvertedToDecimalArray[i]))
                {
                    counterOfPowerOfTwo++;
                }
            }
            Console.WriteLine("There are {0} numbers that are power of two", counterOfPowerOfTwo);
        }

        private static bool isPowerOfTwo(int i_BinaryNumConvertedToDecimal)
        {
            bool isPowerOfTwo = false;
            if (i_BinaryNumConvertedToDecimal == 1) // edge case for 2^0.
            {
                isPowerOfTwo = true;
            }
            while (i_BinaryNumConvertedToDecimal > 2)
                i_BinaryNumConvertedToDecimal /= 2;
            if (i_BinaryNumConvertedToDecimal == 2)
            {
                isPowerOfTwo = true;
            }
            return isPowerOfTwo;
        }

        private static void PrintAverageOnes(string[] i_binaryStrNumArray)
        {
            const char k_charToCheck = '1';
            int numOfOnes = 0;
            for (int i = 0; i < i_binaryStrNumArray.Length; i++)
            {
                numOfOnes += countStrChar(i_binaryStrNumArray[i], k_charToCheck);
            }
            float averageOnes = ((float)numOfOnes / (float)i_binaryStrNumArray.Length); //TODO: CHANGE HERE
            Console.WriteLine("The average number of ones is {0}", averageOnes);
        }

        private static void PrintAverageZeros(string[] i_binaryStrNumArray)
        {
            const char k_charToCheck = '0';
            int numOfZeros = 0;
            for (int i = 0; i < i_binaryStrNumArray.Length; i++)
            {
                numOfZeros += countStrChar(i_binaryStrNumArray[i], k_charToCheck);
            }
            double averageZeros = numOfZeros / i_binaryStrNumArray.Length;
            Console.WriteLine("The average number of zeros is {0}", averageZeros);
        }

        private static int countStrChar(string i_BinaryStrNum, char i_CharToCheck)
        {
            int counter = 0;
            foreach (char c in i_BinaryStrNum)
            {
                if (c == i_CharToCheck)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}

