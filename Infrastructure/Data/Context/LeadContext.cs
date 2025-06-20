using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class LeadContext : DbContext
    {
        public LeadContext(DbContextOptions<LeadContext> options) : base(options) { }

        public DbSet<Lead> Leads => Set<Lead>();
    }
}
