using System;
using ConsoleClient;
using ClassLibrary.Interfaces;
using ClassLibrary;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Json;
using Newtonsoft;
using Newtonsoft.Json;

namespace RandomNumberGame.ConsoleClient
{
    public class Program
    {


        //microservices, dependency injection
        private static readonly ServiceProvider serviceProvider
          = new ServiceCollection()
        .AddScoped<IGenerateCode, GenerateCode>()
        .AddScoped<IHints, Hints>()
        .AddScoped<IPlayer, Player>()
        .AddScoped<IValidate, Validate>()
        .AddTransient<IPlayGame, PlayGame>()
        .BuildServiceProvider(true);

        //HTTP client 
        static HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Program p = new Program();
            await p.GetPlayerInfo();

            //specify Web API base address
            //client.BaseAddress =
              //  new Uri("http://localhost:44338");

            //specify headers
            var val = "application/json";
            var media =
                new MediaTypeWithQualityHeaderValue(val);

            //associate mediatype with client, clears default headers and adds new headers
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(media);

            if (serviceProvider.Equals(null))
            {
                Console.WriteLine("Error");
            }

            IServiceScope scope = serviceProvider.CreateScope();
            var a = scope.ServiceProvider.GetRequiredService<IPlayGame>();

            if (a.Equals(null))
            {
                Console.WriteLine("Error");
            }

            a.RunGame();
        }


        private async Task GetPlayerInfo()
        {
            //uri: Uniform Resource Identifier, is a sequence of characters that identifies a web resource by location, name, or both in the World Wide Web
            var action = $"https://localhost:44338/api/Player/info"; 

            //sends GET request to API
            var request = client.GetAsync(action);

            var response = await request.Result.Content.ReadAsStringAsync();
            var a = response.GetType();
            Console.WriteLine(response);

            List<Player> playerInfo = JsonConvert.DeserializeObject<List<Player>>(response);

            foreach (var item in playerInfo)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
