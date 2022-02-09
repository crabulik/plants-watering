using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using PlantsWatering.Server.Features.Plants;
using PlantsWatering.Server.Validators;
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
            [FromServices] IGetAllPlantsFeature feature)
        {
            return Ok(await feature.HandleAsync());
        }

        // GET api/plants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantDto>> Get(int id,
            [FromServices] IGetPlantByIdFeature feature)
        {
            var model = new GetPlantByIdRequestDto
            {
                Id = id
            };
            var result = await feature.ValidateAsync(model);
            if(result.IsValid)
            {
                return Ok(await feature.HandleAsync(model));
            } 
            else
            {
                if (result.Errors.Exists(p => string.Equals(p.ErrorCode, ValidationErrorCodes.NotFoundEntity)))
                {
                    return NotFound();
                } 
                else
                {
                    result.AddToModelState(ModelState, null);
                    return BadRequest(ModelState);
                }
            }
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
