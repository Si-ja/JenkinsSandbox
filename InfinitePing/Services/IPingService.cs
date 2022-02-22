using InfinitePing.Models;
using System.Threading.Tasks;

namespace InfinitePing.Services
{
    public interface IPingService
    {
        /// <summary>
        /// Ping a port indicated in a settings configuration and return data retrieved with it.
        /// </summary>
        /// <param name="settings">A model carrying settings information for where to send a ping.</param>
        /// <returns>A task with data retrieved from a ping created.</returns>
        Task<string> PingIt(Settings settings);
    }
}
