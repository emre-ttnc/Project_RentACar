using Application.Features.Commands.ModelCommands;
using Application.Features.Queries.ModelQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RentACar.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelsController : ControllerBase
{
    private readonly IMediator _mediatr;

    public ModelsController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _mediatr.Send(new GetAllModelsQuery()));

    [HttpPost]
    public async Task<IActionResult> AddNewModel([FromBody] CreateModelCommand request) =>
        Ok(await _mediatr.Send(request));

    [HttpDelete]
    public async Task<IActionResult> RemoveModel([FromBody] RemoveModelCommand request) =>
        Ok(await _mediatr.Send(request));

    [HttpPost("[action]")]
    public async Task<IActionResult> UpdateModel([FromBody] UpdateModelCommand request) =>
        Ok(await _mediatr.Send(request));
}
