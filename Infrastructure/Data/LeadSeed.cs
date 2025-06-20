using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data.Context;

namespace Infrastructure.Data
{
    public static class LeadSeed
    {
        public static void Initialize(LeadContext context)
        {
            if (context.Leads.Any())
                return;
            var leads = new List<Lead>
            {
                new Lead{
                Id = 123456,
                FirstName = "Maria",
                FullName = "Maria Eduarda Silva",
                Email = "duda@email.com",
                Category = "Automóvel",
                PhoneNumber = "1234567890",
                CreatedDate = DateTime.Now,
                Description = "Venda de carro seminovo",
                Price = 50000,
                Suburb = "Beira Mar",
                Status = LeadStatusEnum.Invited
                },
                new Lead{
                Id = 364823,
                FirstName = "José",
                FullName = "José Carlos Santos",
                Email = "carlos@email.com",
                Category = "Automóvel",
                PhoneNumber = "1234567890",
                CreatedDate = DateTime.Now,
                Description = "Venda de carro seminovo",
                Price = 50000,
                Suburb = "Beira Mar",
                Status = LeadStatusEnum.Invited
                }
            };

            context.Leads.AddRange(leads);
            context.SaveChanges();
        }
    }
    }
