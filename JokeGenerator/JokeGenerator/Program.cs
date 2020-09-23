using System;
using System.Security.Cryptography.X509Certificates;
using JokeGenerator.ClientAPI;
using JokeGenerator.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JokeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Title for Console Application
            Console.Title = "Joke Generator";
            
            ServiceCollection serviceCollection = new ServiceCollection();
            AddServices(serviceCollection);

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<Generator>().GenerateJokes();
        }

        static void AddServices(IServiceCollection services)
        {
            services.AddHttpClient<IChuckNorrisAPI, ChuckNorrisAPI>();
            services.AddHttpClient<INameGeneratorAPI, NameGeneratorAPI>();
            services.AddSingleton<IJokeService, JokeService>(x => new JokeService(x.GetService<IChuckNorrisAPI>(), x.GetService<INameGeneratorAPI>()));
            services.AddSingleton(x => new Generator(x.GetService<IJokeService>()));
        }
    }
}
