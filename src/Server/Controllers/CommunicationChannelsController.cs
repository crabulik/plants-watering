using Microsoft.AspNetCore.Mvc;
using PlantsWatering.Server.Features.Channels;
using PlantsWatering.Shared.Dtos.Channels;

namespace PlantsWatering.Server.Controllers
{
    [ApiController]
    [Route("api/communication-channels")]
    public class CommunicationChannelsController : ControllerBase
    { 
        private readonly IGetAvailableCommunicationChannelsFeature _getAvailableCommunicationChannelsFeature;

        public CommunicationChannelsController(IGetAvailableCommunicationChannelsFeature getAvailableCommunicationChannelsFeature)
        {
            _getAvailableCommunicationChannelsFeature = getAvailableCommunicationChannelsFeature;
        }

        [HttpGet("available")]
        [Produces(typeof(CommunicationChannelDto[]))]
        public async Task<CommunicationChannelDto[]> GetAvailable()
        {
            return await _getAvailableCommunicationChannelsFeature.HandleAsync();
        }
    }
}
