using Domain.Enums;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands.AcceptLead
{
    public class AcceptLeadHandler : IRequestHandler<AcceptLeadCommand>
    {
        private readonly ILeadRepository _repository;
        private readonly IEmailService _emailService;

        public AcceptLeadHandler(ILeadRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public async Task Handle(AcceptLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _repository.GetByIdAsync(request.Id);
            if (lead == null)
                throw new Exception("Lead não encontrado.");

            if (lead.Status != LeadStatusEnum.Invited)
                throw new Exception("Lead já foi processado.");

            if (lead.Price > 500)
                lead.Price *= 0.9m;

            lead.Status = LeadStatusEnum.Accepted;
            await _repository.UpdateAsync(lead);

            await _emailService.SendEmailAsync("vendas@test.com",
               "Lead Aceito",
               $"Lead {lead.FullName} foi aceito.");
        }
    }
}
