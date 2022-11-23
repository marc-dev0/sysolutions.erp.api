using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Products.Queries.GetProductByAll
{
    public class GetProductByAllQuery : IRequest<Response<IEnumerable<GetProductByAllResponse>>>
    {
    }
}
