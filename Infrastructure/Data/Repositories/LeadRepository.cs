using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly LeadContext _context;

        public LeadRepository(LeadContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lead>> GetByStatusAsync(LeadStatusEnum status) =>
            await _context.Leads.Where(l => l.Status == status).ToListAsync();

        public async Task<Lead?> GetByIdAsync(int id) =>
            await _context.Leads.FindAsync(id);

        public async Task UpdateAsync(Lead lead)
        {
            _context.Leads.Update(lead);
            await _context.SaveChangesAsync();
        }
    }
}
