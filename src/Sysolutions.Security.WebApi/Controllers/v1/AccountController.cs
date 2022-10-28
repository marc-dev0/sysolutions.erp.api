using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Sysolutions.Security.Application.Services.Accounts.Commands.AddAccountCommand;
using Sysolutions.Security.Application.Services.Accounts.Commands.AddTokenCommand;
using Microsoft.AspNetCore.Http;
using Sysolutions.Security.Application.Commons;

namespace Sysolutions.Security.WebApi.Controllers.v1
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
