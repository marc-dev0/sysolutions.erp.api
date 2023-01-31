using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Products.Commands.AddProductCommand;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using Sysolutions.Erp.Infrastructure.Persistences.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Measures.Commands.AddMeasureCommand
{
    public class AddMeasureCommand : IRequest<Response<bool>>
    {
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string State { get; set; }
        public int RegistrationAccountId { get; set; }
    }

    public class AddMeasureHandler : IRequestHandler<AddMeasureCommand, Response<bool>>
    {
        private readonly IMeasureRepository _measureRepository;
        private readonly IMapper _mapper;

        public AddMeasureHandler(IMeasureRepository measureRepository, IMapper mapper)
        {
            _measureRepository = measureRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(AddMeasureCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            try
            {
                var product = _mapper.Map<Measure>(request);

                response.Data = await _measureRepository.InsertAsync(product);

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
            catch (Exception)
            {
                throw;
            }

            return response;
        }
    }
}
