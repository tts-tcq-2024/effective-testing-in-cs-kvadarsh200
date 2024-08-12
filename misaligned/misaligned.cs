using System;
using System.Diagnostics;

namespace MisalignedSpace {
    class Misaligned {
        static int printColorMap() {
            string[] majorColors = {"White", "Red", "Black", "Yellow", "Violet"};
            string[] minorColors = {"Blue", "Orange", "Green", "Brown", "Slate"};
            int i = 0, j = 0;
            for(i = 0; i < 5; i++) {
                for(j = 0; j < 5; j++) {
                    Console.WriteLine("{0} | {1} | {2}", i * 5 + j, majorColors[i], minorColors[i]);
                }
            }
            return i * j;
        }
        static void Main(string[] args) {
            int result = printColorMap();
            Debug.Assert(result == 25);
            // Capture the console output
            StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Call the printColorMap method
            int result = printColorMap();

            // Reset the console output to standard output
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });

            // Get the captured output as a string
            string output = consoleOutput.ToString();

            // Assert that the total number of lines is 25
            Debug.Assert(result == 25);

            // Assert that the specific incorrect line is not present
            Debug.Assert(!output.Contains("1 | White | Orange"));

            Console.WriteLine("All is well (maybe!)");

            
        }
    }
}
