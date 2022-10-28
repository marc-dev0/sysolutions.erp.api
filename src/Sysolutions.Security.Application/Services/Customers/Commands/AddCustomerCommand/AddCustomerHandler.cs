using AutoMapper;
using Sysolutions.Security.Application.Commons;
using Sysolutions.Security.Domain.Entities;
using Sysolutions.Security.Infrastructure.Persistences.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Security.Application.Services.Customers.Commands.AddCustomerCommand
{
    public class AddCustomerHandler : IRequestHandler<AddCustomerCommand, Response<bool>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public AddCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(request);
                response.Data = await _customerRepository.InsertAsync(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
                else
                {
                    response.Message = "Registro Fallido!!!";
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
