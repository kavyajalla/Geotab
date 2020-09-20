using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator.ClientAPI
{
    class ChuckNorrisAPI : IChuckNorrisAPI
    {
        private readonly HttpClient _client;
        public ChuckNorrisAPI(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://api.chucknorris.io/jokes/");
            _client = httpClient;
        }

        /// <summary>
        /// Gets random joke from Chuck Norris API
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetRandomJoke()
        {
            return await _client.GetStringAsync("random");
        }

        /// <summary>
        /// Gets joke categories from Chuck Norris API
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetCategories()
        {
            return await _client.GetStringAsync("categories");
        }

        /// <summary>
        /// Gets joke of a category from Chuck Norris API
        /// </summary>
        /// <param name="category">category of joke</param>
        /// <returns></returns>
        public async Task<string> GetJokeFromCategory(string category)
        {
            return await _client.GetStringAsync("random?category=" + category);
        }
    }
}
