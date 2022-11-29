using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Domain.Entities;
using System.Collections.Generic;

namespace Sysolutions.Erp.Application.Services.Sales.Commands.AddSalesOrderCommand
{
    public class AddSalesOrderCommand : IRequest<Response<bool>>
    {
        public string Comment { get; set; }
        public decimal Total { get; set; }
        public string State { get; set; }
        public int RegistrationAccountId { get; set; }
        public IEnumerable<AddSalesOrderDetailViewModel> Detail { get; set; }
    }
}
