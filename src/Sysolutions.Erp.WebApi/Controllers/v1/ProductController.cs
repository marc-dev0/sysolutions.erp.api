using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sysolutions.Erp.Application.Commons;
using System.Threading.Tasks;
using System;
using Sysolutions.Erp.Application.Services.Products.Queries.GetProductByAll;
using Sysolutions.Erp.Application.Services.Accounts.Commands.AddAccountCommand;
using Sysolutions.Erp.Application.Services.Products.Commands.AddProductCommand;
using Sysolutions.Erp.Application.Services.Products.Queries.GetPresentationsByProductId;
using Sysolutions.Erp.Application.Services.Products.Commands.DeleteProductCommand;
using Sysolutions.Erp.Application.Services.Products.Queries.GetProductByIdQuery;

namespace Sysolutions.Erp.WebApi.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(Response<GetProductByAllResponse>), StatusCodes.Status200OK)]
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetProductByAllQuery query)
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

        [ProducesResponseType(typeof(Response<GetPresentationsByProductIdResponse>), StatusCodes.Status200OK)]
        [HttpGet("GetPresentationsByProductId")]
        public async Task<IActionResult> GetPresentationsByProductId(int productId)
        {
            try
            {
                var response = await _mediator.Send(new GetPresentationsByProductIdQuery(productId));
                return response.IsSuccess ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [ProducesResponseType(typeof(Response<GetProductByIdResponse>), StatusCodes.Status200OK)]
        [HttpGet("GetProductByIdAsync")]
        public async Task<IActionResult> GetProductByIdAsync(int productId)
        {
            try
            {
                var response = await _mediator.Send(new GetProductByIdQuery() { ProductId = productId });
                return response.IsSuccess ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Operación que permite crear un nuevo Producto.
        /// </summary>
        /// <param name="addProductCommand">addProductCommand</param>
        /// <returns></returns>
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] AddProductCommand addProductCommand)
        {
            if (addProductCommand is null)
                return BadRequest();

            var response = await _mediator.Send(addProductCommand);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// Operación que permite crear un nuevo Producto.
        /// </summary>
        /// <param name="deleteProductCommand">deleteProductCommand</param>
        /// <returns></returns>
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int productId, int modifiedAccountId)
        {
            try
            {
                var response = await _mediator.Send(new DeleteProductCommand() { ProductId = productId, ModifiedAccountId = modifiedAccountId });
                return response.IsSuccess ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
