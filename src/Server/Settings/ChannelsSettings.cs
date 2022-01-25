namespace PlantsWatering.Server.Settings
{
    public class ChannelsSettings
    {
        public ConfiguredCommunicationChannel[] DeviceChannels { get; set; } = new ConfiguredCommunicationChannel[0];
    }

    public class ConfiguredCommunicationChannel
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}
