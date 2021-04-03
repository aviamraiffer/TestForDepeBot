using System;

namespace B21_Ex01_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            initiateProgram();
        }

        private static void initiateProgram()
        {
            int heightOfSandClock = readInput();    // Reads an integer from the user.
            heightOfSandClock = patchEvenNumber(heightOfSandClock); // Handles even number inputs.
            Console.WriteLine("Input read successfully. Initiating sand clock print of height {0}:", heightOfSandClock);
            B21_Ex01_2.Program.PrintSandClock(heightOfSandClock);   // Prints a sand clock of height heightOfSandClock.
        }

        private static int patchEvenNumber(int io_heightOfSandClock)
        {
            bool isEvenInput = B21_Ex01_1.Program.IsEven(io_heightOfSandClock); // Checks if the input is an even number.
            if (isEvenInput)    // If it is an even number, increase it by 1 and inform the user.
            {
                io_heightOfSandClock++;
                Console.WriteLine("As a result of an even input, the desired height of the sand clock is changed to {0}.", io_heightOfSandClock);
            }
            return io_heightOfSandClock;
        }

        private static int readInput()
        {
            Console.WriteLine("Enter the desired height of the sand clock:");
            string heightOfSandClockStr = Console.ReadLine();
            while (!isValidInput(heightOfSandClockStr)) // As long as the input is invalid, keep asking for a valid input.
            {
                Console.WriteLine("This input is invalid. Please enter a natural number:");
                heightOfSandClockStr = Console.ReadLine();
            }
            int o_heightOfSandClock = int.Parse(heightOfSandClockStr);
            return o_heightOfSandClock;
        }

        private static bool isValidInput(string i_heightOfSandClockStr)
        {
            bool o_isValid = isAllDigits(i_heightOfSandClockStr) && !isEmpty(i_heightOfSandClockStr); // Checks if the input is a number and is not empty.
            return o_isValid;
        }

        private static bool isEmpty(string i_heightOfSandClockStr)
        {
            bool o_isEmpty = i_heightOfSandClockStr == ""; // Assigns true if the input is an empty string.
            return o_isEmpty;
        }

        private static bool isAllDigits(string i_heightOfSandClockStr)
        {
            bool o_isAllDigits = true;
            foreach (char c in i_heightOfSandClockStr) // Iterate through each char of the received string.
            {
                bool charIsDigit = Char.IsDigit(c);
                if (!charIsDigit) // If a char is not a digit, assign o_isAllDigits to be false and exit the loop.
                {
                    o_isAllDigits = false;
                    break;
                }
            }
            return o_isAllDigits;
        }
    }
}
