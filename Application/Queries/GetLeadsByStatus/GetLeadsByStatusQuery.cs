using Application.DTOs;
using Domain.Enums;
using MediatR;

namespace Application.Queries.GetLeadsByStatus
{
    public record GetLeadsByStatusQuery(LeadStatusEnum Status) : IRequest<List<LeadDto>>;
}
