using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sysolutions.Erp.Application.Services.EntryNotes.Commands.AddEntryNoteCommand;
using Sysolutions.Erp.Application.Services.Products.Commands.AddProductCommand;
using System.Threading.Tasks;

namespace Sysolutions.Erp.WebApi.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EntryNoteController : Controller
    {
        private readonly IMediator _mediator;

        public EntryNoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Operación que permite crear una nueva nota de ingreso
        /// </summary>
        /// <param name="addEntryNoteCommand">addEntryNoteCommand</param>
        /// <returns></returns>
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] AddEntryNoteCommand command)
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
