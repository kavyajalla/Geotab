using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator.Services
{
    interface IJokeService
    {
        /// <summary>
        /// Gets a random joke
        /// </summary>
        /// <returns></returns>
        string GetRandomJoke();

        /// <summary>
        /// Gets list of categories
        /// </summary>
        /// <returns></returns>
        List<string> GetCategories();

        /// <summary>
        /// Gets firstname and lastname as a tuple
        /// </summary>
        /// <returns></returns>
        Tuple<string, string> GetName();

        /// <summary>
        /// Gets joke from a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        string GetJokeFromCategory(string category);

        /// <summary>
        /// Replaces Chuck Norris name with given name in a joke
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="joke"></param>
        /// <returns></returns>
        string GetJokeWithNameReplaced(string firstName, string lastName, string joke);

        /// <summary>
        /// Checks if given category is in list of categories
        /// </summary>
        /// <param name="category">category name passed</param>
        /// <returns></returns>
        Boolean CheckIfValidCategory(string category);

        /// <summary>
        /// Gets list of jokes with given name and categories
        /// </summary>
        /// <param name="name">tuple with firstname and lastname</param>
        /// <param name="category">category name</param>
        /// <param name="numOfJokes">num of jokes to be returned</param>
        /// <returns></returns>
        List<string> GetRandomJokesWithParameteres(Tuple<string, string> name, string category, int numOfJokes);
    }
}
