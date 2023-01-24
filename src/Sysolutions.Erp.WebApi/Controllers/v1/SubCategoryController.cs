using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Categories.Queries.GetCategoryByAll;
using System.Threading.Tasks;
using System;
using Sysolutions.Erp.Application.Services.SubCategories.Queries.GetSubCategoryByCategoryId;
using Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountById;
using Sysolutions.Erp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Sysolutions.Erp.WebApi.Controllers.v1
{
    
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SubCategoryController : Controller
    {
        private readonly IMediator _mediator;

        public SubCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [ProducesResponseType(typeof(Response<GetSubCategoryByCategoryIdResponse>), StatusCodes.Status200OK)]
        [HttpGet("GetByCategoryIdAsync")]
        public async Task<IActionResult> GetByCategoryIdAsync(int categoryId)
        {
            try
            {
                var response = await _mediator.Send(new GetSubCategoryByCategoryIdQuery() { CategoryId = categoryId});
                return response.IsSuccess ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
