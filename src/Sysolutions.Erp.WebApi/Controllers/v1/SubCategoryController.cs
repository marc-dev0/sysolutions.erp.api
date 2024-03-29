﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sysolutions.Erp.Application.Commons;
using System.Threading.Tasks;
using System;
using Sysolutions.Erp.Application.Services.SubCategories.Queries.GetSubCategoryByCategoryId;
using Sysolutions.Erp.Application.Services.SubCategories.Commands.AddSubCategoryCommand;
using Sysolutions.Erp.Application.Services.SubCategories.Queries.GetSubCategoryByAllQuery;

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

        [ProducesResponseType(typeof(Response<GetSubCategoryByAllResponse>), StatusCodes.Status200OK)]
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetSubCategoryByAllQuery query)
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

        /// <summary>
        /// Operación que permite crear una nueva SubCategoría
        /// </summary>
        /// <param name="addSubCategoryCommand">addSubCategoryCommand</param>
        /// <returns></returns>
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] AddSubCategoryCommand command)
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
