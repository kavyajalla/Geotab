using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator.ClientAPI
{
    interface IChuckNorrisAPI
    {
        /// <summary>
        /// Gets random joke from Chuck Norris API
        /// </summary>
        /// <returns></returns>
        Task<string> GetRandomJoke();

        /// <summary>
        /// Gets joke categories from Chuck Norris API
        /// </summary>
        /// <returns></returns>
        Task<string> GetCategories();

        /// <summary>
        /// Gets joke of a category from Chuck Norris API
        /// </summary>
        /// <param name="category">category of joke</param>
        /// <returns></returns>
        Task<string> GetJokeFromCategory(string category);
    }
}
