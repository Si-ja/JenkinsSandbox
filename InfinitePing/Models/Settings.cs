namespace InfinitePing.Models
{
    public class Settings
    {
        public int PingPort { get; set; }

        public int Pause { get; set; }

        public string DeploymentStatus { get; set; }

        public string URL { get; set; }

        public string CallDestination { get; set; }

        public string FullURL => URL + ":" + PingPort + "/" + CallDestination;
    }
}
