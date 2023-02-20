using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Dtos;
using Sysolutions.Erp.Application.Services.Customers.Commands.AddCustomerCommand;
using Sysolutions.Erp.Application.Services.Customers.Commands.DeleteCustomerCommand;
using Sysolutions.Erp.Application.Services.Customers.Commands.UpdateCustomerCommand;
using Sysolutions.Erp.Application.Services.Customers.Queries.GetCustomerAllQuery;
using Sysolutions.Erp.Application.Services.Customers.Queries.GetCustomerByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sysolutions.Erp.WebApi.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(Response<IEnumerable<CustomerDto>>), StatusCodes.Status200OK)]
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetCustomerAllQuery());
            return response.IsSuccess ? Ok(response) : BadRequest(response);

            //if (response.IsSuccess)
            //    return Ok(response);
            //else
            //    return BadRequest(response);
        }

        [HttpGet("GetAsync/{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            var response = await _mediator.Send(new GetCustomerByIdQuery() { CustomerId = customerId });
            return response.IsSuccess ? Ok(response) : BadRequest(response);

            //if (response.IsSuccess)
            //    return Ok(response);
            //else
            //    return BadRequest(response);
        }

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] AddCustomerCommand addCustomerCommand)
        {
            if (addCustomerCommand is null)
                return BadRequest();

            var response = await _mediator.Send(addCustomerCommand);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCustomerCommand command)
        {
            if (command is null)
                return BadRequest();

            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("DeleteAsync/{customerId}")]
        public async Task<IActionResult> DeleteAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();

            var response = await _mediator.Send(new DeleteCustomerCommand() { CustomerId = customerId });
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
