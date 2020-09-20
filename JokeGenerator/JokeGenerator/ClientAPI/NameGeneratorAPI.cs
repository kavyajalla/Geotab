using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator.ClientAPI
{
    class NameGeneratorAPI : INameGeneratorAPI
    {
        private readonly HttpClient _client;
        public NameGeneratorAPI(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://www.names.privserv.com/api");
            _client = httpClient;
        }

        /// <summary>
        /// Get name object from PrivServ API
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetNames()
        {
            return await _client.GetStringAsync("");
        }
    }
}
