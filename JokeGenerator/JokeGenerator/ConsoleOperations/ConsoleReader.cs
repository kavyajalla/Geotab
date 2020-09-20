using System;
using System.Collections.Generic;
using System.Text;

namespace JokeGenerator.ConsoleOperations
{
    class ConsoleReader
    {
        /// <summary>
        /// //Get user input line
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <returns></returns>
        public static string ReadLineFromConsole(string promptMessage = "")
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// //Get user input key
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <param name="consoleKeyInfo"></param>
        /// <returns></returns>
        public static char ReadKeyFromConsole(ConsoleKeyInfo consoleKeyInfo, string promptMessage = "")
        {
            char key;
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.C:
                    key = 'c';
                    break;
                case ConsoleKey.D0:
                    key = '0';
                    break;
                case ConsoleKey.D1:
                    key = '1';
                    break;
                case ConsoleKey.D2:
                    key = '2';
                    break;
                case ConsoleKey.D3:
                    key = '3';
                    break;
                case ConsoleKey.D4:
                    key = '4';
                    break;
                case ConsoleKey.D5:
                    key = '5';
                    break;
                case ConsoleKey.D6:
                    key = '6';
                    break;
                case ConsoleKey.D7:
                    key = '7';
                    break;
                case ConsoleKey.D8:
                    key = '8';
                    break;
                case ConsoleKey.D9:
                    key = '9';
                    break;
                case ConsoleKey.R:
                    key = 'r';
                    break;
                case ConsoleKey.Y:
                    key = 'y';
                    break;
                case ConsoleKey.N:
                    key = 'n';
                    break;
                case ConsoleKey.X:
                    key = 'x';
                    break;
                default:
                    key = '-';
                    break;
            }

            return key;
        }
    }
}
