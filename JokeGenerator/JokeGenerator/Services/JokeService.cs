using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using JokeGenerator.ClientAPI;
using Newtonsoft.Json;

namespace JokeGenerator.Services
{
    class JokeService : IJokeService
    {
        IChuckNorrisAPI _chuckNorrisAPI;
        INameGeneratorAPI _nameGeneratorAPI;
        public JokeService(IChuckNorrisAPI chuckNorrisAPI, INameGeneratorAPI nameGeneratorAPI)
        {
            _chuckNorrisAPI = chuckNorrisAPI;
            _nameGeneratorAPI = nameGeneratorAPI;
        }

        /// <summary>
        /// Gets a random joke
        /// </summary>
        /// <returns></returns>
        public string GetRandomJoke()
        {
            string joke = _chuckNorrisAPI.GetRandomJoke().Result;
            joke = JsonConvert.DeserializeObject<dynamic>(joke).value;
            return joke;
        }

        /// <summary>
        /// Gets list of categories
        /// </summary>
        /// <returns></returns>
        public List<string> GetCategories()
        {
            string categories = _chuckNorrisAPI.GetCategories().Result;
            List<string> categoryList = JsonConvert.DeserializeObject<List<string>>(categories);
            return categoryList;
        }

        /// <summary>
        /// Gets firstname and lastname as a tuple
        /// </summary>
        /// <returns></returns>
        public Tuple<string, string> GetName()
        {
            string namesResult = _nameGeneratorAPI.GetNames().Result;
            dynamic result = JsonConvert.DeserializeObject<dynamic>(namesResult);
            Tuple<string, string>  names = Tuple.Create(result.name.ToString(), result.surname.ToString());
            return names;
        }

        /// <summary>
        /// Gets joke from a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public string GetJokeFromCategory(string category)
        {
            string joke = _chuckNorrisAPI.GetJokeFromCategory(category).Result;
            joke = JsonConvert.DeserializeObject<dynamic>(joke).value;
            return joke;
        }

        /// <summary>
        /// Replaces Chuck Norris name with given name in a joke
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="joke"></param>
        /// <returns></returns>
        public string GetJokeWithNameReplaced(string firstName, string lastName, string joke)
        {
            if (firstName != null && lastName != null)
            {
                int index = joke.IndexOf("Chuck Norris");
                string firstPart = joke.Substring(0, index);
                string secondPart = joke.Substring(0 + index + "Chuck Norris".Length, joke.Length - (index + "Chuck Norris".Length));
                joke = firstPart + " " + firstName + " " + lastName + secondPart;
            }
            return joke;
        }

        /// <summary>
        /// Checks if given category is in list of categories
        /// </summary>
        /// <param name="category">category name passed</param>
        /// <returns></returns>
        public Boolean CheckIfValidCategory(string category)
        {
            List<string> categories = GetCategories();
            if(categories.Contains(category))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets list of jokes with given name and categories
        /// </summary>
        /// <param name="name">tuple with firstname and lastname</param>
        /// <param name="category">category name</param>
        /// <param name="numOfJokes">num of jokes to be returned</param>
        /// <returns></returns>
        public List<string> GetRandomJokesWithParameteres(Tuple<string,string> name, string category, int numOfJokes)
        {
            List<string> jokeList = new List<string>();

            string joke = "";
            for(int i=0; i < numOfJokes; i++)
            {
                if(category != null)
                {
                    joke = GetJokeFromCategory(category);
                }
                else
                {
                    joke = GetRandomJoke();
                }

                if(name != null)
                {
                    joke = GetJokeWithNameReplaced(name.Item1, name.Item2, joke);
                }

                jokeList.Add(joke);
            }

            return jokeList;
        }
    }
}
