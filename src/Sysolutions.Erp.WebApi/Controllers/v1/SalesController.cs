using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Accounts.Commands.AddAccountCommand;
using Sysolutions.Erp.Application.Services.Products.Queries.GetProductByAll;
using Sysolutions.Erp.Application.Services.Sales.Commands.AddSalesOrderCommand;
using Sysolutions.Erp.Application.Services.Sales.Queries.GetSalesOrderByAllQuery;
using System;
using System.Threading.Tasks;

namespace Sysolutions.Erp.WebApi.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SalesController : Controller
    {
        private readonly IMediator _mediator;

        public SalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Operación que permite crear una orden de venta.
        /// </summary>
        /// <param name="AddSalesOrderCommand">addAccountCommand</param>
        /// <returns></returns>
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] AddSalesOrderCommand command)
        {
            if (command is null)
                return BadRequest();

            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        [ProducesResponseType(typeof(Response<GetProductByAllResponse>), StatusCodes.Status200OK)]
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetSalesOrderByAllQuery query)
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
