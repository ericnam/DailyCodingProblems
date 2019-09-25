using System;
using Problems;

namespace DailyCodingProblems
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHeader();
            while (true) {
                Console.WriteLine("Input problem #:");
                string userInput = "search";
                int problemNumber = 0;

                if (userInput == "sort") {
                    SortingAlgorithms SortingAlgorithms = new SortingAlgorithms();
                    SortingAlgorithms.Main();
                }
                else if (userInput == "LinkedList") {
                    LinkedListTest linkedList = new LinkedListTest();
                    linkedList.Main();
                }
                else if (userInput == "Fib") {
                    Fib fib = new Fib();
                    fib.Main();
                }
                else if (userInput == "search") {
                    SearchingAlgorithms search = new SearchingAlgorithms();
                    search.Main();
                }
                else
                {
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
                            case 29:
                                Problem29 problem29 = new Problem29();
                                problem29.Main();
                                break;
                            case 37:
                                Problem37 problem37 = new Problem37();
                                problem37.Main();
                                break;
                            case 44:
                                Problem44 problem44 = new Problem44();
                                problem44.Main();
                                break;
                            case 57:
                                Problem57 problem57 = new Problem57();
                                problem57.Main();
                                break;
                            default:
                                break;
                        }
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
