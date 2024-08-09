using MassUprising24.API.Model;
using MassUprising24.DataAccess.CQRS.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MassUprising24.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarriorController : ControllerBase
    {
        private IMediator _mediator;

        public WarriorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Warrior(CreateWarriorCmd cmd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<object>(false, "Invalid data", ModelState));
            }
            else
            {
                try
                {
                    var result = await _mediator.Send(cmd);
                    if (result.Success)
                    {
                        return Ok(new ApiResponse<object>(true, result.Message, result.Id));
                    }
                    return BadRequest(new ApiResponse<object>(false, result.Message, null));

                }
                catch (Exception)
                {
                    return StatusCode(
                        StatusCodes.Status500InternalServerError,
                    new ApiResponse<object>(false, "An error occurred during Warrior create.", null)
                    );
                }
            }
        }

        [HttpPost("Address")]
        public async Task<IActionResult> Address(CreateAddressCmd cmd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<object>(false, "Invalid data", ModelState));
            }
            else
            {
                try
                {
                    var result = await _mediator.Send(cmd);
                    if (result.Success)
                    {
                        return Ok(new ApiResponse<object>(true, result.Message, result.Id));
                    }
                    return BadRequest(new ApiResponse<object>(false, result.Message, null));
                }
                catch (Exception)
                {
                    return StatusCode(
                      StatusCodes.Status500InternalServerError,
                  new ApiResponse<object>(false, "An error occurred during Warrior create.", null));
                }
            }
        }
    }
}