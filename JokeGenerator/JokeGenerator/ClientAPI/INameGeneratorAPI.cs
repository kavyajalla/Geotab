using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator.ClientAPI
{
    interface INameGeneratorAPI
    {
        Task<string> GetNames();
    }
}
