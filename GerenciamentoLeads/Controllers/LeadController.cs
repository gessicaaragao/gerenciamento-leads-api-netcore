using Application.Commands.AcceptLead;
using Application.Commands.DeclineLead;
using Application.Queries.GetLeadsByStatus;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace GerenciamentoLeads.Controllers
{
    [ApiController]
    [Route("api/leads")]
    public class LeadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("invited")]
        public async Task<IActionResult> GetInvited()
        {
            try
            {
                var result = await _mediator.Send(new GetLeadsByStatusQuery(LeadStatusEnum.Invited));

                if (!result.Any())
                    return NotFound(); 
                
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro interno ao buscar os leads.", details = ex.Message });
            }
        }

        [HttpGet("accepted")]
        public async Task<IActionResult> GetAccepted()
        {
            try
            {
                var result = await _mediator.Send(new GetLeadsByStatusQuery(LeadStatusEnum.Accepted));

                if (!result.Any())
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro interno ao buscar os leads.", details = ex.Message });
            }
        }

        [HttpPost("{id}/accept")]
        public async Task<IActionResult> Accept(int id)
        {
            try
            {
                await _mediator.Send(new AcceptLeadCommand(id));
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro interno ao aceitar o lead.", details = ex.Message });
            }
        }

        [HttpPost("{id}/decline")]
        public async Task<IActionResult> Decline(int id)
        {
            try
            {
                await _mediator.Send(new DeclineLeadCommand(id));
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro interno ao recusar o lead.", details = ex.Message });
            }
        }
    }
}
