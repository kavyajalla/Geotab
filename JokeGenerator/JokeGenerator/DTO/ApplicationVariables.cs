using System;
using System.Collections.Generic;
using System.Text;

namespace JokeGenerator.DTO
{
    class ApplicationVariables
    {
        public char key {get; set;}
        public char yesNoKey {get; set;}
        public Boolean validCategory { get; set; }
        public List<string> categoryList { get; set; }
        public Tuple<string, string> name { get; set; }
        public int numOfJokes {get; set;}
        public List<string> jokeList { get; set; }
        public string categoryName { get; set; }
    }
}
