using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Lead
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string FullName { get; set; } 
        public string Email { get; set; } 
        public string PhoneNumber { get; set; } 
        public DateTime CreatedDate { get; set; }
        public string Suburb { get; set; } 
        public string Category { get; set; } 
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public LeadStatusEnum Status { get; set; }
    }
}
