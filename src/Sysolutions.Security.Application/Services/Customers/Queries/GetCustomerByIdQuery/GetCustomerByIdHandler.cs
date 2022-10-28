using AutoMapper;
using Sysolutions.Security.Application.Commons;
using Sysolutions.Security.Application.Dtos;
using Sysolutions.Security.Infrastructure.Persistences.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Security.Application.Services.Customers.Queries.GetCustomerByIdQuery
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Response<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerByIdHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Response<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<CustomerDto>();
            try
            {
                var customer = await _customerRepository.GetAsync(request.CustomerId);
                if (customer is not null)
                {
                    response.Data = _mapper.Map<CustomerDto>(customer);
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
