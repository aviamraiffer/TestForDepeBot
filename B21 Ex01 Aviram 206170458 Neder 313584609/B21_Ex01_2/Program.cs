using System;
using System.Text;

namespace B21_Ex01_2
{
    public class Program
    {
        const int k_heightOfSandClock = 5;
        public static void Main(string[] args)
        {
            initiateProgram();
        }

        private static void initiateProgram()
        {
            PrintSandClock(k_heightOfSandClock);
        }

        public static void PrintSandClock(int i_heightOfSandClock)
        {
            StringBuilder sandClockLine = new StringBuilder();
            for(int i = 0; i < i_heightOfSandClock; i++) // Append as many '*' as required to the string.
            {
                sandClockLine.Append('*');
            } 
            Console.WriteLine(sandClockLine.ToString());
            if (sandClockLine.Length <= 1)
            {
                return;
            }
            string sandClockNextLine = sandClockLine.ToString().Substring(0, sandClockLine.Length - 2); // Trimming 2 '*' for the next line.
            printSandClock(sandClockNextLine);
            Console.WriteLine(sandClockLine.ToString());

        }

        private static void printSandClock(string i_sandClockLine)
        {
            string paddedSandClockLine = i_sandClockLine.Insert(0, " "); // Pads the string with a ' ' to align it.
            Console.WriteLine(paddedSandClockLine);
            bool isOnlyOne = i_sandClockLine.IndexOf('*') == i_sandClockLine.LastIndexOf('*'); // Checks if there is only 1 '*' in the string.
            if (isOnlyOne)
            {
                return; // ######## Will Guy like it? ########
            }
            string sandClockNextLine = paddedSandClockLine.Substring(0, paddedSandClockLine.Length - 2); // Trimming 2 '*' for the next line.
            printSandClock(sandClockNextLine);
            Console.WriteLine(paddedSandClockLine);

        }
    }
}
