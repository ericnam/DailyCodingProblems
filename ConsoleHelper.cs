using System;

namespace Helpers
{
    class ConsoleHelper {
        public static void PrintPrompt (string prompt) {    
            Console.WriteLine(new String('-', 50));        
            Console.Write(prompt);            
            Console.WriteLine(new String('-', 50));
        }

        public static string GetIntArrayInput () {
            Console.WriteLine("Input int array, comma delimited");
            Console.WriteLine("(e.g. 1, 2, 3, 4, 5)");
            return Console.ReadLine();
        }
    }
}