using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Sysolutions.Erp.Application.Services.Accounts.Commands.AddAccountCommand;
using Sysolutions.Erp.Application.Services.Accounts.Commands.AddTokenCommand;
using Microsoft.AspNetCore.Http;
using Sysolutions.Erp.Application.Commons;
using System.Diagnostics;
using System;
using Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountByAll;
using Sysolutions.Erp.Application.Services.Customers.Commands.DeleteCustomerCommand;
using Sysolutions.Erp.Application.Services.Accounts.Commands.DeleteAccountCommand;
using Sysolutions.Erp.Application.Services.Customers.Queries.GetCustomerByIdQuery;
using Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountById;
using Sysolutions.Erp.Application.Services.Accounts.Commands.UpdateAccountCommand;

namespace Sysolutions.Erp.WebApi.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAsync/{customerId}")]
        public async Task<IActionResult> GetAsync(GetCustomerByIdQuery getCustomerByIdQuery)
        {
            var response = await _mediator.Send(getCustomerByIdQuery);
            return response.IsSuccess ? Ok(response) : BadRequest(response);

            //if (response.IsSuccess)
            //    return Ok(response);
            //else
            //    return BadRequest(response);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int accountId)
        {
            try
            {
                var response = await _mediator.Send(new GetAccountByIdQuery(accountId));
                return response.IsSuccess ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [ProducesResponseType(typeof(Response<GetAccountByAllResponse>), StatusCodes.Status200OK)]
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAccountByAllQuery query)
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
        /// Operación que permite crear una nueva Cuenta.
        /// </summary>
        /// <param name="addAccountCommand">addAccountCommand</param>
        /// <returns></returns>
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] AddAccountCommand addAccountCommand)
        {
            if (addAccountCommand is null)
                return BadRequest();

            var response = await _mediator.Send(addAccountCommand);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// Operación que permite actualizar una cuenta.
        /// </summary>
        /// <param name="addAccountCommand">addAccountCommand</param>
        /// <returns></returns>
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountCommand updateAccountCommand)
        {
            if (updateAccountCommand is null)
                return BadRequest();
            try
            {
                var response = await _mediator.Send(updateAccountCommand);
                if (response.IsSuccess)
                    return Ok(response);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int accountId,int modifiedAccountId)
        {
            /*if (command is null)
                return BadRequest();*/

            var response = await _mediator.Send(new DeleteAccountCommand(accountId, modifiedAccountId));
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// Operación que permite generar un TOKEN a partir de un client y secret.
        /// </summary>
        /// <param name="addTokenCommand">addTokenCommand</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [AllowAnonymous]
        [HttpPost("TokenAsync")]
        public async Task<IActionResult> TokenAsync([FromBody] AddTokenCommand addTokenCommand)
        {
            if (addTokenCommand is null)
                return BadRequest();

            var response = await _mediator.Send(addTokenCommand);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
