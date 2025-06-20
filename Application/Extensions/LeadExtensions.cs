using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class LeadExtensions
    {
        public static LeadDto ToDto(this Lead lead)
        {
            return new LeadDto
            {
                Id = lead.Id,
                FirstName = lead.FirstName,
                FullName = lead.FullName,
                PhoneNumber = lead.PhoneNumber,
                Email = lead.Email,
                Suburb = lead.Suburb,
                Category = lead.Category,
                Description = lead.Description,
                Price = lead.Price,
                CreatedDate = lead.CreatedDate
            };
        }
    }
}
