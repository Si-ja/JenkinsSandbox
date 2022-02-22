using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using InfinitePing.Models;
using InfinitePing.Services;
using System.Threading.Tasks;

namespace InfinitePing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Perform a setup with required in the future parameters and conditions
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(ConfigurationReferences.AppSettings, optional: false)
                .Build();

            var settings = config.GetSection(ConfigurationReferences.PingSettings).Get<Settings>();
            var pingService = PingServiceFactory.generatePingService(settings);
            
            // Yes, this is an infinite loop. Just close it when needed
            while(true)
            {
                var answer = pingService.PingIt(settings);
                await answer;
                Console.WriteLine(answer.Result);
            }
        }
    }
}
