using AutoMapper;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Dtos;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Customers.Queries.GetCustomerAllQuery
{
    public class GetCustomerAllHandler : IRequestHandler<GetCustomerAllQuery, Response<IEnumerable<CustomerDto>>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerAllHandler(ICustomerRepository customerRepository, IMapper mapper = null)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<CustomerDto>>> Handle(GetCustomerAllQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<CustomerDto>>();
            try
            {
                var customers = await _customerRepository.GetAllAsync();
                if (customers is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
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
