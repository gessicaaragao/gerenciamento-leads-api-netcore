using MediatR;

namespace Application.Commands.DeclineLead
{
    public record DeclineLeadCommand(int Id) : IRequest;
}
