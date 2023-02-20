using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Accounts.Commands.AddAccountCommand;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using Sysolutions.Erp.Infrastructure.Persistences.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Sales.Commands.AddSalesOrderCommand
{
    public class AddSalesOrderHandler : IRequestHandler<AddSalesOrderCommand, Response<bool>>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;

        public AddSalesOrderHandler(ISalesRepository salesRepository, IMapper mapper)
        {
            _salesRepository = salesRepository;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(AddSalesOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            try
            {
                var mapRequest = _mapper.Map<SalesOrder>(request);

                response.Data = await _salesRepository.InsertAsync(mapRequest);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso.";
                }
                else
                {
                    response.Message = "Registro Fallido.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
