using System;

namespace Ex01
{
    /*
     * in isEven, shouldn't we just return the condition? ask Itamar. 
     */
    public class Program
    {
        const int k_lengthOfInput = 7;
        const int k_numOfInputs = 3;
        public static void Main()
        {
            initiateProgram();
        }

        private static void initiateProgram()
        {
            string[] binaryStrNumArray = readBinaryNumsArray(); //Reads binary numbers as strings and validates their format, 
            int[] binaryConvertedToDecimalArray = convertToDecimalArray(binaryStrNumArray); //converts all binary strings to decimal numbers.
            printDecimalArray(binaryConvertedToDecimalArray); //Prints the array of decimal numbers.
            printStatistics(binaryStrNumArray, binaryConvertedToDecimalArray); //Prints statistics regarding binary numbers and their decimal presentation.

            Console.WriteLine("Press ENTER to terminate the program");
            Console.ReadLine();
        }

        private static void printDecimalArray(int[] i_binaryConvertedToDecimalArray)
        {
            Console.WriteLine("The decimal representation of the inputs are (respectively):");
            for (int i = 0; i < k_numOfInputs; i++)
            {
                Console.WriteLine(i_binaryConvertedToDecimalArray[i]);
            }
        }

        private static int[] convertToDecimalArray(string[] i_binaryStrNumArray)
        {
            int[] o_binaryConvertedToDecimal = new int[i_binaryStrNumArray.Length];
            for (int i = 0; i < i_binaryStrNumArray.Length; i++)
            {
                o_binaryConvertedToDecimal[i] = convertBinaryStrToDecimal(i_binaryStrNumArray[i]);
            }
            return o_binaryConvertedToDecimal;
        }

        private static int convertBinaryStrToDecimal(string i_binaryStr)
        {
            int o_decimalNum = 0;  // The decimal number to be returned.
            int binaryNum = int.Parse(i_binaryStr); // The binary number stored in an int variable.
            int leastSignificantBit = 0; // The least significant bit(LSB) of binaryNum (the rightmost digit).
            for (int i = 0; i < i_binaryStr.Length; i++)
            {
                leastSignificantBit = binaryNum % 10; // extract the LSB from binaryNum.
                o_decimalNum += (int)Math.Pow(2, i) * leastSignificantBit; // if the LSB is 1, add 2^i to decimalNum where i is the index of the LSB
                binaryNum /= 10; // cut the LSB from binaryNum.
            }
            return o_decimalNum;
        }

        private static string[] readBinaryNumsArray()
        {
            string[] o_binaryNumbersArray = new string[k_numOfInputs]; // A string array that will contain the binary inputs as strings.
            for (int i = 0; i < k_numOfInputs; i++)
            {
                o_binaryNumbersArray[i] = readBinaryNum(); // Reads a binary input into the array.
            }
            return o_binaryNumbersArray;
        }

        private static string readBinaryNum()
        {
            Console.WriteLine(
 @"Please enter a {0}-digit binary format number
and press enter ", k_lengthOfInput);
            string o_binaryNumberStr = Console.ReadLine(); // Reads an input into the string.
            while (!isValid(o_binaryNumberStr)) // Re-read an input into the string if it is not valid.
            {
                Console.WriteLine(
 @"The input was invalid.
Please re-enter a {0}-digit binary format number
and press enter ", k_lengthOfInput);
                o_binaryNumberStr = Console.ReadLine();
            }
            return o_binaryNumberStr;
        }

        private static bool isValid(string i_binaryStr)
        {
            bool o_isValid = false;
            o_isValid = (i_binaryStr.Length == k_lengthOfInput && isBinary(i_binaryStr)); // Assigns valid to be true if it is indeed binary and of proper length.
            return o_isValid;
        }

        private static bool isBinary(string i_binaryStr)
        {
            bool o_isBinary = true;
            for (int i = 0; i < i_binaryStr.Length; i++)
            {
                if (!i_binaryStr[i].Equals('0') && !i_binaryStr[i].Equals('1'))
                {
                    o_isBinary = false; // Assigns false to isBinary in case a character is neither '0' nor '1'.
                    break;
                }
            }
            return o_isBinary;
        }

        private static void printStatistics(string[] i_binaryStrNumArray, int[] i_binaryConvertedToDecimalArray)
        {
            printAverageZerosp(i_binaryStrNumArray);
            printAverageOnes(i_binaryStrNumArray);
            printPowerofTwo(i_binaryConvertedToDecimalArray);
            printAscendingSeriesofDigits(i_binaryConvertedToDecimalArray);
            printMinAndMaxNum(i_binaryConvertedToDecimalArray);
        }

        private static void printMinAndMaxNum(int[] i_binaryConvertedToDecimalArray)
        {
            int minNumIndex = 0; // the index of the min number of the array.
            int maxNumIndex = 0; // the index of the max number of the array.
            for (int i = 0; i < i_binaryConvertedToDecimalArray.Length; i++) // Iterates through the whole array and checks:
            {
                if (i_binaryConvertedToDecimalArray[i] < i_binaryConvertedToDecimalArray[minNumIndex]) // If the number in the current index 'i' is lesser than the minNumIndex, set minNumIndex to be 'i'.
                {
                    minNumIndex = i;
                }
                else if (i_binaryConvertedToDecimalArray[i] > i_binaryConvertedToDecimalArray[maxNumIndex]) // If the number in the current index 'i' is greater than the maxNumIndex, set maxNumIndex to be 'i'.
                {
                    maxNumIndex = i;
                }
            }
            Console.WriteLine("The minimal number in the array is {0}", i_binaryConvertedToDecimalArray[minNumIndex]);
            Console.WriteLine("The maximal number in the array is {0}", i_binaryConvertedToDecimalArray[maxNumIndex]);
        }

        private static void printAscendingSeriesofDigits(int[] i_binaryConvertedToDecimalArray)
        {
            int counterOfAscendingSeriesNumbers = 0; // Counts the number of ascending series numbers.
            for (int i = 0; i < i_binaryConvertedToDecimalArray.Length; i++)
            {
                if (isAscendingSeries(i_binaryConvertedToDecimalArray[i])) // Raise the counter by 1 if the number is an ascending series number.
                {
                    counterOfAscendingSeriesNumbers++;
                }
            }
            if (counterOfAscendingSeriesNumbers == 1) // Textual edge case.
            {
                Console.WriteLine("there is {0} input whos decimal representation is a strictly ascending order", counterOfAscendingSeriesNumbers);
            }
            else
            {
                Console.WriteLine("there are {0} inputs whos decimal representation is a strictly ascending order", counterOfAscendingSeriesNumbers);
            }
        }

        private static bool isAscendingSeries(int i_binaryNumConvertedToDecimal)
        {
            bool o_isAscedingSeries = true;
            int digitOfUnits = 0; // Stores the digit of the units (the rightmost digit).
            int digitOfTens = 0; // Stores the digit of the tens (the second rightmost digit).

            while (i_binaryNumConvertedToDecimal != 0)
            {
                digitOfUnits = i_binaryNumConvertedToDecimal % 10; // Extracts the rightmost digit from i_binaryNumConvertedToDecimal to digitOfUnits.
                i_binaryNumConvertedToDecimal /= 10; // Removes the current rightmost digit from i_binaryNumConvertedToDecimal.
                digitOfTens = i_binaryNumConvertedToDecimal % 10; // Extracts the second rightmost digit from i_binaryNumConvertedToDecimal to digitOfTens.
                if (!(digitOfTens < digitOfUnits))
                {
                    o_isAscedingSeries = false; // Assigns false in case the rightmost digit isn't strictly bigger than the second rightmost digit.
                    break;
                }
            }
            return o_isAscedingSeries;
        }

        private static void printPowerofTwo(int[] i_binaryConvertedToDecimalArray)
        {
            int counterOfPowerOfTwo = 0; // Counts how many numbers are a power of two.
            for (int i = 0; i < i_binaryConvertedToDecimalArray.Length; i++)
            {
                if (isPowerOfTwo(i_binaryConvertedToDecimalArray[i]))
                {
                    counterOfPowerOfTwo++; // Raise the counter by 1 in case a number is indeed a power of two.
                }
            }
            if (counterOfPowerOfTwo == 1) // Textual edge case.
            {
                Console.WriteLine("There is {0} number that is a power of two", counterOfPowerOfTwo);
            }
            else
            {
                Console.WriteLine("There are {0} numbers that are power of two", counterOfPowerOfTwo);
            }
        }

        private static bool isPowerOfTwo(int i_binaryNumConvertedToDecimal)
        {
            bool o_isPowerOfTwo = false;
            o_isPowerOfTwo = i_binaryNumConvertedToDecimal == 1; // Edge case for 2^0.
            while (isEven(i_binaryNumConvertedToDecimal)) // As long as the number is even, check if it equals to 2 and divide it by 2.
            {
                o_isPowerOfTwo = i_binaryNumConvertedToDecimal == 2;
                i_binaryNumConvertedToDecimal /= 2;
            }
            return o_isPowerOfTwo;
        }

        private static bool isEven(int i_binaryNumConvertedToDecimal)
        {
            bool o_isEven = true;
            o_isEven = i_binaryNumConvertedToDecimal % 2 == 0; // If division by 2 has no remainder, then the number is indeed even.
            return o_isEven;
        }

        private static void printAverageOnes(string[] i_binaryStrNumArray)
        {
            const char k_charToCheck = '1';
            int numOfOnes = 0; // Counts the number of ones across all inputs.
            for (int i = 0; i < i_binaryStrNumArray.Length; i++)
            {
                numOfOnes += countStrChar(i_binaryStrNumArray[i], k_charToCheck); // Returns how many k_charToCheck('1') are in a single string.
            }
            float averageOnes = ((float)numOfOnes / (float)i_binaryStrNumArray.Length); // Compute average ones.
            Console.WriteLine("The average number of ones is {0}", averageOnes);
        }

        private static void printAverageZerosp(string[] i_binaryStrNumArray)
        {
            const char k_charToCheck = '0';
            int numOfZeros = 0; // Counts the number of zeros across all inputs.

            for (int i = 0; i < i_binaryStrNumArray.Length; i++)
            {
                numOfZeros += countStrChar(i_binaryStrNumArray[i], k_charToCheck); // Returns how many k_charToCheck('0') are in a single string.
            }
            float averageZeros = (float)numOfZeros / (float)i_binaryStrNumArray.Length; // Compute average zeros.
            Console.WriteLine("The average number of zeros is {0}", averageZeros);
        }

        private static int countStrChar(string i_binaryStrNum, char i_charToCheck)
        {
            int counter = 0; // Counts how many i_charToCheck are there in i_binaryStrNum.
            foreach (char c in i_binaryStrNum)
            {
                if (c == i_charToCheck)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}

