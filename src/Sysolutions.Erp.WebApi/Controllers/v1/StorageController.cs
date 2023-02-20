using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Sysolutions.Erp.Application.Services.Storages.Commands;
using Sysolutions.Erp.Application.Commons;
using Microsoft.AspNetCore.Http;
using System;
using Sysolutions.Erp.Application.Services.Storages.Queries.GetStorageByAllQuery;
using Sysolutions.Erp.Application.Services.SubCategories.Queries.GetSubCategoryByCategoryId;
using Sysolutions.Erp.Application.Services.Storages.Queries.GetStorageProductByStorageIdQuery;

namespace Sysolutions.Erp.WebApi.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StorageController : Controller
    {
        private readonly IMediator _mediator;

        public StorageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(Response<GetStorageByAllResponse>), StatusCodes.Status200OK)]
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetStorageByAllQuery query)
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
        /// <param name="addStorageCommand">addStorageCommand</param>
        /// <returns></returns>
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] AddStorageCommand command)
        {
            if (command is null)
                return BadRequest();

            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        [ProducesResponseType(typeof(Response<GetStorageProductByStorageIdResponse>), StatusCodes.Status200OK)]
        [HttpGet("GetStorageProductByStorageIddAsync")]
        public async Task<IActionResult> GetStorageProductByStorageIddAsync(int storageId, int categoryId, int subCategoryId, string description)
        {
            try
            {
                var response = await _mediator.Send(new GetStorageProductByStorageIdQuery() { StorageId = storageId, CategoryId = categoryId, SubCategoryId = subCategoryId, Description = description });
                return response.IsSuccess ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
