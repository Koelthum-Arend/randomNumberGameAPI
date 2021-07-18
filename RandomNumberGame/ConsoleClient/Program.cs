using System;
using ConsoleClient;
using ClassLibrary.Interfaces;
using ClassLibrary;
using Microsoft.Extensions.DependencyInjection;
using ClassLibrary.GameDTO;
using ClassLibrary;

namespace RandomNumberGame.ConsoleClient
{
    public class Program
    {
        

        //microservices
        //private static readonly ServiceProvider _serviceProvider
        //  = new ServiceCollection()
        //.AddScoped<IGenerateCode, GenerateCode>()
        //.AddScoped<IHints, Hints>()
        //.AddScoped<IPlayer, Player>()
        //.BuildServiceProvider();
        public Program() 
        {
            GameInfoDTO _gameInfoDTO;

        }
        private static readonly ServiceProvider _DI = ConfigureServices();

        static void Main(string[] args)
        {
            if (_DI.Equals(null))
            {
                Console.WriteLine("Error");
            }

            IServiceScope scope = _DI.CreateScope();
            var a = scope.ServiceProvider.GetRequiredService<IPlayGame>();

            if (a.Equals(null))
            {
                Console.WriteLine("Error");
            }

            a.RunGame();
        }
        //create a new class 
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<IGenerateCode, GenerateCode>()
             .AddScoped<IHints, Hints>()
             .AddScoped<IPlayer, Player>()
             .AddScoped<IGenerateCode, GenerateCode>()
             .AddScoped<IPlayGame, PlayGame>()
             .AddScoped<IValidate, Validate>();

            return services.BuildServiceProvider(true);
        }
    }
}
