using ManagementAPI.Application.Features.Commands.ManagementTypeCommands.CreateManagementType;
using ManagementAPI.Application.Features.Commands.ManagementTypeCommands.DeleteManagementType;
using ManagementAPI.Application.Features.Commands.ManagementTypeCommands.UpdateManagementType;
using ManagementAPI.Application.Features.Queries.ManagementTypeQueries.GetAllDetailsOfManagementTypes;
using ManagementAPI.Application.Features.Queries.ManagementTypeQueries.GetAllManagementTypes;
using ManagementAPI.Application.Features.Queries.ManagementTypeQueries.GetManagementTypeByParentId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagementAPI.API.Controllers;

public class ManagementTypeController : Controller
{
    private readonly IMediator _mediator;

    public ManagementTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAllManagementTypes")]
    public async Task<IActionResult> GetAllManagementTypes([FromQuery] GetAllManagementTypesQueryRequest request)
    {
        GetAllManagementTypesQueryResponse response = await _mediator.Send(request);
        return Ok(response);

    }
    [HttpGet("GetAllDetailsOfManagementTypes")]
    public async Task<IActionResult> GetAllDetailsOfManagementTypes([FromQuery] GetAllDetailsOfManagementTypesRequest request)
    {

        GetAllDetailsOfManagementTypesResponse response = await _mediator.Send(request);
        response = await _mediator.Send(request);
        return Ok(response);

    }

    [HttpGet("GetManagementTypeByParentId")]
    public async Task<IActionResult> GetManagementTypeByParentId([FromQuery] GetManagementTypeByParentIdQueryRequest request)
    {

        GetManagementTypeByParentIdQueryResponse response = await _mediator.Send(request);
        response = await _mediator.Send(request);
        return Ok(response);

    }


    [HttpPost("AddManagementType")]
    public async Task<IActionResult> AddManagementType(CreateManagementTypeCommandRequest request)
    {
        CreateManagementTypeCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("UpdateManagementType")]
    public async Task<IActionResult> UpdateManagementType(UpdateManagementTypeCommandRequest request)
    {

        UpdateManagementTypeCommandResponse response = await _mediator.Send(request);
        return Ok(response);

    }
    [HttpDelete("SoftDeleteManagementType")]
    public async Task<IActionResult> SoftDeleteManagementType(DeleteManagementTypeCommandRequest request)
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
