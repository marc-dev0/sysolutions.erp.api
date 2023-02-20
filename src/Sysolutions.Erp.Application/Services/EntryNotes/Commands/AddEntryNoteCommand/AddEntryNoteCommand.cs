using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.EntryNotes.Commands.AddEntryNoteCommand
{
    public class AddEntryNoteCommand : IRequest<Response<bool>>
    {
        public int EntryNoteId { get; set; }
        public string Correlative { get; set; }
        public string State { get; set; }
        public int RegistrationAccountId { get; set; }
        public decimal CostPriceTotal { get; set; }
        public IEnumerable<EntryNoteDetail> EntryDetails { get; set; }
    }

    public class AddEntryNoteHandler : IRequestHandler<AddEntryNoteCommand, Response<bool>>
    {
        private readonly IEntryNoteRepository _entryNoteRepository;
        private readonly IMapper _mapper;

        public AddEntryNoteHandler(IEntryNoteRepository entryNoteRepository, IMapper mapper)
        {
            _entryNoteRepository = entryNoteRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(AddEntryNoteCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            try
            {
                var product = _mapper.Map<EntryNote>(request);

                response.Data = await _entryNoteRepository.InsertAsync(product);

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
