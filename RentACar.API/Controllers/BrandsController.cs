using Application.Features.Commands.BrandCommands;
using Application.Features.Queries.BrandQueries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RentACar.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly IMediator _mediatr;

    public BrandsController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles ="Customer")] //For testing
    public async Task<IActionResult> Add(CreateBrandCommand request) =>
        Created("", await _mediatr.Send(request));

    [HttpDelete]
    public async Task<IActionResult> Remove(RemoveBrandCommand request) =>
        Ok(await _mediatr.Send(request));

    [HttpGet(Name = nameof(GetAll))]
    public async Task<IActionResult> GetAll() =>
        Ok(await _mediatr.Send(new GetAllBrandsQuery()));

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateBrandCommand request) =>
        Ok(await _mediatr.Send(request));

    [HttpPost(nameof(GetAllByDynamic))]
    public async Task<IActionResult> GetAllByDynamic(GetAllBrandsByDynamicQuery request) =>
        Ok(await _mediatr.Send(request));
}
