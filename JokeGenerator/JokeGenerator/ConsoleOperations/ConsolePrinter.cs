using System;
using System.Collections.Generic;
using System.Text;

namespace JokeGenerator.ConsoleOperations
{
    class ConsolePrinter
    {
        public static void WriteMessageToConsole(string message = "")
        {
            if (message.Length > 0)
            {
                Console.WriteLine(message);
            }
        }

        public static void WriteMessageValueToConsole(string message, string value)
        {
            if (message.Length > 0)
            {
                Console.WriteLine(message + value);
            }
        }

        public static void WriteListContentsToConsole(List<string> list, string listName)
        {
            Console.WriteLine("------------------------------------------" + listName + " starts here"+ "------------------------------------------");
            list.ForEach(Console.WriteLine);
            Console.WriteLine("------------------------------------------" + listName + " end here" + "------------------------------------------");
        }
    }
}
