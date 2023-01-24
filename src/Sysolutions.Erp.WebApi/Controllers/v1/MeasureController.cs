using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sysolutions.Erp.Application.Commons;
using System.Threading.Tasks;
using System;
using Sysolutions.Erp.Application.Services.Measures.Queries.GetMeasureByAll;
using Microsoft.AspNetCore.Authorization;

namespace Sysolutions.Erp.WebApi.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MeasureController : Controller
    {
        private readonly IMediator _mediator;

        public MeasureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(Response<GetMeasureByAllResponse>), StatusCodes.Status200OK)]
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetMeasureByAllQuery query)
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
