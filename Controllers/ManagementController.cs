using ManagementAPI.Application.Features.Commands.ManagementCommands.CreateManagement;
using ManagementAPI.Application.Features.Commands.ManagementCommands.DeleteManagement;
using ManagementAPI.Application.Features.Commands.ManagementCommands.UpdateManagement;
using ManagementAPI.Application.Features.Queries.ManagementQueries.GetAllManagements;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagementAPI.API.Controllers
{
    public class ManagementController : Controller
    {
        private readonly IMediator _mediator;

        public ManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAllActiveManagements")]
        public async Task<IActionResult> GetAllActiveManagements([FromQuery] GetAllManagementsQueryRequest request)
        {
            GetAllManagementsQueryResponse response = await _mediator.Send(request);
            return Ok(response);

        }
        [HttpGet("GetAllManagements")]
        public async Task<IActionResult> GetAllManagements([FromQuery] GetAllManagementsQueryRequest request)
        {
            GetAllManagementsQueryResponse response = await _mediator.Send(request);
            return Ok(response);

        }
        [HttpGet("GetAllDetailsOfManagements")]
        public async Task<IActionResult> GetAllDetailsOfManagements([FromQuery] GetAllManagementsQueryRequest request)
        {
            GetAllManagementsQueryResponse response = await _mediator.Send(request);
            response = await _mediator.Send(request);
            return Ok(response);

        }


        [HttpPost("AddManagement")]
        public async Task<IActionResult> AddManagement(CreateManagementCommandRequest request)
        {
            CreateManagementCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("UpdateManagement")]
        public async Task<IActionResult> UpdateManagement(UpdateManagementCommandRequest request)
        {

            UpdateManagementCommandResponse response = await _mediator.Send(request);
            return Ok(response);

        }
        [HttpDelete("SoftDeleteManagement")]
        public async Task<IActionResult> SoftDeleteManagement(DeleteManagementCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.Success)
            {
                return Ok(new { isSuccess = true });

            }
            else
            {
                return BadRequest(new { isSuccess = false, errorMessage = response.ErrorMessage });
            }
        }
    }
}
