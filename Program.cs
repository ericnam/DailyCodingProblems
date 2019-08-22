using System;
using Problems;

namespace DailyCodingProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHeader();
            while (true) {
                Console.WriteLine("Input problem #:");
                string userInput = "1";
                int problemNumber = 0;
                bool validInput = Int32.TryParse(userInput, out problemNumber);
                if (validInput) {                    
                    switch (problemNumber) {
                        case 1:
                            Problem1 problem1 = new Problem1();
                            problem1.Main();
                            break;
                        case 21:
                            Problem21 problem21 = new Problem21();
                            problem21.Main();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        static void CreateHeader () 
        {
            const string headerText = "Daily Coding Challenges";
            Console.WriteLine();
            Console.WriteLine(headerText);
            Console.WriteLine(new String('-', headerText.Length));
            Console.WriteLine();            
        }
    }

}
