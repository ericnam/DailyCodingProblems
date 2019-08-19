using System;

namespace DailyCodingProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHeader();

            Console.WriteLine("Input problem #:");

            bool exitApplication = false;

            while (!exitApplication) {

            }

            string codingProblemNumber = Console.ReadLine();
        }

        static void CreateHeader () {
            const string headerText = "Daily Coding Challenges";
            Console.WriteLine();
            Console.WriteLine(headerText);
            Console.WriteLine(new String('-', headerText.Length));
            Console.WriteLine();
            Console.WriteLine("Input the ");
            
        }
    }

}
