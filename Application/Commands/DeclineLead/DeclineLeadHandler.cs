using Application.Commands.AcceptLead;
using Domain.Enums;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands.DeclineLead
{
    public class DeclineLeadHandler : IRequestHandler<DeclineLeadCommand>
    {
        private readonly ILeadRepository _repository;

        public DeclineLeadHandler(ILeadRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeclineLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _repository.GetByIdAsync(request.Id);
            if (lead == null)
                throw new Exception("Lead não encontrado.");

            if (lead.Status != LeadStatusEnum.Invited)
                throw new Exception("Lead já foi processado.");

            lead.Status = LeadStatusEnum.Declined;
            await _repository.UpdateAsync(lead);
        }
    }
}
