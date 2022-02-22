using InfinitePing.Models;
using System;
using System.Threading.Tasks;

namespace InfinitePing.Services
{
    public class PingNothing : IPingService
    {
        public async Task<string> PingIt(Settings settings)
        {
            await Task.Delay(settings.Pause);
            return "This was a successful test...\n";
        }
    }
}
