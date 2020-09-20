using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using JokeGenerator.ConsoleOperations;
using JokeGenerator.DTO;
using JokeGenerator.Services;

namespace JokeGenerator
{
    class Generator
    {
        public IJokeService _jokeService;
        public Generator(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        /// <summary>
        /// This method sets up initial app layout
        /// </summary>
        public void GenerateJokes()
        {
            ConsolePrinter.WriteMessageToConsole("------------------------------------------------------------------------------------------------------------------------");
            ConsolePrinter.WriteMessageToConsole("------------------------------------------------------------------------------------------------------------------------");
            ConsolePrinter.WriteMessageToConsole("                                        Welcome to Joke Generator");
            ConsolePrinter.WriteMessageToConsole("------------------------------------------------------------------------------------------------------------------------");
            ConsolePrinter.WriteMessageToConsole("------------------------------------------------------------------------------------------------------------------------");
            ConsolePrinter.WriteMessageToConsole("This app gets random Chuck Norris jokes and can substitute random names into the joke instead of Chuck Norris");
            ConsolePrinter.WriteMessageToConsole("You can also select a category for a joke and number of jokes you wish to get");
            ConsolePrinter.WriteMessageToConsole();
            ConsolePrinter.WriteMessageToConsole("Press ? to get instructions.");
            string key = Console.ReadLine();
            do
            {
                if(key == "?")
                {
                    RunConsole();
                }
                else 
                {
                    ConsolePrinter.WriteMessageToConsole("Please enter ? to get instructions.");
                    key = Console.ReadLine();
                }
            } while(true);            
        }

        /// <summary>
        /// Function to enter commands and generate jokes
        /// </summary>
        public void RunConsole()
        {
            ApplicationVariables appVariables = new ApplicationVariables();

            while (true)
            {
                ConsolePrinter.WriteMessageToConsole("Press c to get categories");
                ConsolePrinter.WriteMessageToConsole("Press r to get random jokes");
                ConsolePrinter.WriteMessageToConsole("Press x to exit the application.");
                ConsolePrinter.WriteMessageToConsole();
                appVariables.key = ConsoleReader.ReadKeyFromConsole(Console.ReadKey());

                do
                {
                    //If user selects to get list of categories
                    if (appVariables.key == 'c')
                    {
                        appVariables.categoryList = _jokeService.GetCategories();
                        ConsolePrinter.WriteListContentsToConsole(appVariables.categoryList, "Categories");
                        ConsolePrinter.WriteMessageToConsole();
                        break;
                    }
                    //If user selects to get random joke
                    else if (appVariables.key == 'r')
                    {
                        ConsolePrinter.WriteMessageToConsole("Want to use a random name? y/n ");
                        appVariables.yesNoKey = ConsoleReader.ReadKeyFromConsole(Console.ReadKey());

                        //If user selects to get random joke
                        do
                        {
                            if (appVariables.yesNoKey == 'y')
                            {
                                appVariables.name = _jokeService.GetName();
                                ConsolePrinter.WriteMessageValueToConsole("First Name: ", appVariables.name.Item1);
                                ConsolePrinter.WriteMessageValueToConsole("Last Name: ", appVariables.name.Item2);
                                ConsolePrinter.WriteMessageToConsole();
                                break;
                            }
                            else if (appVariables.yesNoKey == 'n')
                            {
                                appVariables.name = null;
                                break;
                            }
                            else
                            {
                                ConsolePrinter.WriteMessageToConsole("Please enter y or n as input : ");
                                appVariables.yesNoKey = ConsoleReader.ReadKeyFromConsole(Console.ReadKey());
                            }

                        } while (appVariables.yesNoKey != 'y' || appVariables.yesNoKey != 'n');

                        ConsolePrinter.WriteMessageToConsole();
                        ConsolePrinter.WriteMessageToConsole("Want to specify a category? y/n ");
                        appVariables.yesNoKey = ConsoleReader.ReadKeyFromConsole(Console.ReadKey());

                        //If user selects to get joke from category
                        do
                        {
                            if (appVariables.yesNoKey == 'y')
                            {
                                ConsolePrinter.WriteMessageToConsole();
                                ConsolePrinter.WriteMessageToConsole("Enter a category; ");
                                appVariables.categoryName = ConsoleReader.ReadLineFromConsole();
                                do
                                {
                                    appVariables.validCategory = _jokeService.CheckIfValidCategory(appVariables.categoryName);
                                    if (!appVariables.validCategory)
                                    {
                                        appVariables.categoryName = null;
                                        ConsolePrinter.WriteMessageToConsole();
                                        ConsolePrinter.WriteMessageToConsole("Enter a valid category from the category list : ");
                                        appVariables.categoryName = ConsoleReader.ReadLineFromConsole();
                                    }
                                    else
                                    {
                                        break;
                                    }
                                } while (!appVariables.validCategory);

                                break;
                            }
                            else if (appVariables.yesNoKey == 'n')
                            {
                                appVariables.categoryName = null;
                                break;
                            }
                            else
                            {
                                ConsolePrinter.WriteMessageToConsole();
                                ConsolePrinter.WriteMessageToConsole("Please enter y or n as input : ");
                                appVariables.yesNoKey = ConsoleReader.ReadKeyFromConsole(Console.ReadKey());
                            }

                        } while (appVariables.yesNoKey != 'y' || appVariables.yesNoKey != 'n');

                        ConsolePrinter.WriteMessageToConsole();
                        ConsolePrinter.WriteMessageToConsole("How many jokes do you want? (1-9): ");
                        appVariables.numOfJokes = (int)Char.GetNumericValue(ConsoleReader.ReadKeyFromConsole(Console.ReadKey()));

                        //If user selects to get number of jokes
                        do
                        {
                            if (appVariables.numOfJokes >= 1 && appVariables.numOfJokes <= 9)
                            {
                                appVariables.jokeList = _jokeService.GetRandomJokesWithParameteres(appVariables.name, appVariables.categoryName, appVariables.numOfJokes);
                                ConsolePrinter.WriteListContentsToConsole(appVariables.jokeList, "Jokes");
                                break;
                            }
                            else
                            {
                                ConsolePrinter.WriteMessageToConsole();
                                ConsolePrinter.WriteMessageToConsole("Please enter numbers between 1 to 9 : ");
                                appVariables.numOfJokes = (int)Char.GetNumericValue(ConsoleReader.ReadKeyFromConsole(Console.ReadKey()));
                            }
                        } while (appVariables.numOfJokes < 1 || appVariables.numOfJokes > 9);

                        break;
                    }
                    else if (appVariables.key == 'x')
                    {
                        ExitConsole();
                    }
                    else
                    {
                        ConsolePrinter.WriteMessageToConsole();
                        ConsolePrinter.WriteMessageToConsole("Please enter r or c as input or x to exit from application: ");
                        appVariables.key = ConsoleReader.ReadKeyFromConsole(Console.ReadKey());
                    }

                } while (appVariables.key != 'c' || appVariables.key != 'r' || appVariables.key != 'x');
            }
        }

        /// <summary>
        /// Exits from application
        /// </summary>
        public void ExitConsole()
        {
            Environment.Exit(0);
        }
    }
}
