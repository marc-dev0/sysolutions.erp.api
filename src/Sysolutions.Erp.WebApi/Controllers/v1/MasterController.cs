using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Products.Queries.GetProductByAll;
using System.Threading.Tasks;
using System;
using Sysolutions.Erp.Application.Services.Masters.Queries.GetMasterByAll;

namespace Sysolutions.Erp.WebApi.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MasterController : Controller
    {
        private readonly IMediator _mediator;

        public MasterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(Response<GetMasterByAllResponse>), StatusCodes.Status200OK)]
        [HttpGet("GetCategoryAllAsync")]
        public async Task<IActionResult> GetCategoryAllAsync([FromQuery] GetMasterByAllQuery query)
        {
            try
            {
                var response = await _mediator.Send(query);
                return response.IsSuccess ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
