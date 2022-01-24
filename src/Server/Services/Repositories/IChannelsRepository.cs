namespace PlantsWatering.Server.Services.Repositories
{
    public interface IChannelsRepository
    {
        public Task<CommunicationChannel[]> GetUnusedChannels();
    }
}
