using MediatR;

using Microsoft.AspNetCore.Mvc;
using Test_Backend.API.Controllers.Abstract;
using Test_Backend.API.Dtos;
using Test_Backend.Application.Commands;
using Test_Backend.Application.Queries;

namespace Test_Backend.API.Controllers
{
    public class AdvertisementController : ApiControllerBase
    {
        public AdvertisementController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<AdvertisementDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAdvertisements([FromQuery] ReadAdvertisementQuery query)
        {
            return Many(await QueryAsync(query));
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Insert([FromBody] AddAdvertisementCommand command)
        {
            return Single(await CommandAsync(command));
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update([FromBody] UpdateAdvertisementCommand command)
        {
            return Single(await CommandAsync(command));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Remove([FromBody] RemoveAdvertisementCommand command)
        {
            return Single(await CommandAsync(command));
        }
    }
}
