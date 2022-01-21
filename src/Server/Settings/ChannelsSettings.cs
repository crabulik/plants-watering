namespace PlantsWatering.Server.Settings
{
    public class ChannelsSettings
    {
        public ConfiguredCommunicationChannel[] DeviceChannels { get; set; } = new ConfiguredCommunicationChannel[0];
    }

    public class ConfiguredCommunicationChannel
    {
        public string Id { get; private set; } = string.Empty;

        public string Name { get; private set; } = string.Empty;
    }
}
