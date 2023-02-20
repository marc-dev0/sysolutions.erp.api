using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountByAll
{
    public class GetAccountByAllQuery : IRequest<Response<IEnumerable<GetAccountByAllResponse>>>
    {
        public string Client { get; set; }
    }
}
