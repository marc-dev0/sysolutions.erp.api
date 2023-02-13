using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Sysolutions.Erp.Application.Services.EntryNotes.Queries.GetEntryNotesByAllQuery
{
    public class GetEntryNoteByAllQuery : IRequest<Response<GetBaseEntryNoteByAllResponse>>
    {
    }

    public class GetEntryNoteByAllHandler : IRequestHandler<GetEntryNoteByAllQuery, Response<GetBaseEntryNoteByAllResponse>>
    {
        private readonly IEntryNoteRepository _entryNoteRepository;
        private readonly IMapper _mapper;

        public GetEntryNoteByAllHandler(IEntryNoteRepository entryNoteRepository, IMapper mapper)
        {
            _entryNoteRepository = entryNoteRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetBaseEntryNoteByAllResponse>> Handle(GetEntryNoteByAllQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<GetBaseEntryNoteByAllResponse>();
            try
            {
                var list = await _entryNoteRepository.GetAllAsync();
                if (list is not null)
                {
                    response.Data = _mapper.Map<GetBaseEntryNoteByAllResponse>(list);
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
