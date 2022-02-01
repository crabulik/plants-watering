namespace PlantsWatering.Server.Services.Repositories
{
    public interface IChannelsRepository
    {
        public Task<CommunicationChannel[]> GetUnusedChannelsAsync();

        public Task<bool> GetIsChannelUnusedAsync(string CommunicationChannelId);
    }
}
