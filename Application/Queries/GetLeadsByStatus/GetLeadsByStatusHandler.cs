using Application.DTOs;
using Application.Extensions;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetLeadsByStatus
{
    public class GetLeadsByStatusHandler : IRequestHandler<GetLeadsByStatusQuery, List<LeadDto>>
    {
        private readonly ILeadRepository _repository;

        public GetLeadsByStatusHandler(ILeadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LeadDto>> Handle(GetLeadsByStatusQuery request, CancellationToken cancellationToken)
        {
            var leads = await _repository.GetByStatusAsync(request.Status);

            return leads.Select(l => l.ToDto()).ToList();
        }
    }
}
