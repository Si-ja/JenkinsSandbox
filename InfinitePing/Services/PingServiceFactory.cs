using InfinitePing.Models;
using System;

namespace InfinitePing.Services
{
    public static class PingServiceFactory
    {
        public static IPingService generatePingService(Settings settings)
        {
            return settings.DeploymentStatus.ToLower() switch
            {
                "test" => new PingNothing(),
                "prod" => new PingApi(),
                _ => throw new InvalidOperationException($"No applicable settings were indicated in {nameof(Settings.DeploymentStatus)}"),
            };
        }
    }
}
