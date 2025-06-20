using MediatR;

namespace Application.Commands.AcceptLead
{
    public record AcceptLeadCommand(int Id) : IRequest;
}
