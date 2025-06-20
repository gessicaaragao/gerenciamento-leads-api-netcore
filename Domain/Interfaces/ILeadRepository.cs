using Domain.Entities;
using Domain.Enums;

namespace Domain.Interfaces
{
    public interface ILeadRepository
    {
        Task<IEnumerable<Lead>> GetByStatusAsync(LeadStatusEnum status);
        Task<Lead?> GetByIdAsync(int id);
        Task UpdateAsync(Lead lead);
    }
}
