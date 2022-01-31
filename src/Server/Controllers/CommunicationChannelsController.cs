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
        public async Task<ActionResult<CommunicationChannelDto[]>> GetAvailable()
        {
            return Ok(await _getAvailableCommunicationChannelsFeature.HandleAsync());
        }
    }
}
