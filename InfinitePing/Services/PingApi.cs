using InfinitePing.Models;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace InfinitePing.Services
{
    public class PingApi : IPingService
    {
        public async Task<string> PingIt(Settings settings)
        {
            // Make a short delay
            await Task.Delay(settings.Pause);

            // Prepare the objects that can retrieve information from the web
            WebRequest wrGETURL;
            Stream objStream;

            // Initiate stream retrieval
            wrGETURL = WebRequest.Create(settings.FullURL);
            WebResponse response = await wrGETURL.GetResponseAsync();
            objStream = response.GetResponseStream();

            StreamReader reader = new(objStream);
            string text = reader.ReadToEnd();
            return text;
        }
    }
}
