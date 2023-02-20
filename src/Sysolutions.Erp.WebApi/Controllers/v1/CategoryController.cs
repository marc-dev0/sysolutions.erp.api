using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Products.Queries.GetProductByAll;
using System.Threading.Tasks;
using System;
using Sysolutions.Erp.Application.Services.Categories.Queries.GetCategoryByAll;
using Sysolutions.Erp.Application.Services.Measures.Commands.AddMeasureCommand;
using Sysolutions.Erp.Application.Services.Categories.Commands;

namespace Sysolutions.Erp.WebApi.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(Response<GetCategoryByAllResponse>), StatusCodes.Status200OK)]
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetCategoryByAllQuery query)
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

        /// <summary>
        /// Operación que permite crear una nueva categoría
        /// </summary>
        /// <param name="addCategoryCommand">addCategoryCommand</param>
        /// <returns></returns>
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] AddCategoryCommand command)
        {
            if (command is null)
                return BadRequest();

            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
