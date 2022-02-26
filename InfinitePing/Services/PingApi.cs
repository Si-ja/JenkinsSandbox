using InfinitePing.Models;
using System.IO;
using System.Net;
using System.Net.Http;
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
            HttpClientHandler clientHandler = new();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new(clientHandler);
            Stream objStream;

            // Initiate stream retrieval
            HttpResponseMessage response = await client.GetAsync(settings.FullURL);
            objStream = response.Content.ReadAsStream();

            StreamReader reader = new(objStream);
            string text = reader.ReadToEnd();
            return text;
        }
    }
}
