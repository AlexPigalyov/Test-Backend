using MediatR;

using Microsoft.AspNetCore.Mvc;

using Test_Backend.Application.Commands;
using Test_Backend.Application.Queries;
using Test_Backend.Controllers.Abstract;
using Test_Backend.Domain.Dtos;

namespace Test_Backend.Controllers
{
    public class AuthorController : ApiControllerBase
    {
        public AuthorController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<AuthorDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAdvertisements([FromQuery] ReadAuthorQuery query)
        {
            return Many(await QueryAsync(query));
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Insert([FromBody] AddAuthorCommand command)
        {
            return Single(await CommandAsync(command));
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorCommand command)
        {
            return Single(await CommandAsync(command));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Remove([FromBody] RemoveAuthorCommand command)
        {
            return Single(await CommandAsync(command));
        }
    }
}
