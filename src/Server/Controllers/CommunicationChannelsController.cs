using Microsoft.AspNetCore.Mvc;
using PlantsWatering.Server.Features.Channels;
using PlantsWatering.Shared.Dtos.Channels;

namespace PlantsWatering.Server.Controllers
{
    [ApiController]
    [Route("api/communication-channels")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CommunicationChannelsController : ControllerBase
    { 
        [HttpGet("available")]
        [Produces(typeof(GetAvailableCommunicationChannelsResponceDto))]
        public async Task<ActionResult<GetAvailableCommunicationChannelsResponceDto>> GetAvailable(
            [FromServices]IGetAvailableCommunicationChannelsFeature getAvailableCommunicationChannelsFeature)
        {
            return Ok(await getAvailableCommunicationChannelsFeature.HandleAsync());
        }
    }
}
