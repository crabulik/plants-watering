using Microsoft.AspNetCore.Mvc;
using PlantsWatering.Server.Features.Plants;
using PlantsWatering.Shared.Dtos.Plants;

namespace PlantsWatering.Server.Controllers
{
    [ApiController]
    [Route("api/plants")]
    [Produces("application/json")]
    public class PlantsController : ControllerBase
    {
        // GET: api/plants
        [HttpGet]
        [ProducesResponseType(typeof(GetAllPlantsResponceDto), 200)]
        public async Task<ActionResult<GetAllPlantsResponceDto>> Get(
            [FromServices] IGetAllPlantsFeature getAllPlantsFeature)
        {
            return Ok(await getAllPlantsFeature.HandleAsync());
        }

        // GET api/plants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantDto>> Get([FromRoute]GetPlantByIdRequestDto request)
        {

            return Ok(new PlantDto());
        }

        // POST api/<PlantsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/plants/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/plants/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
