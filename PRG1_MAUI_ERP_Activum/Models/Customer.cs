using System;
using System.Collections.Generic;
using System.Text;

namespace PRG1_MAUI_ERP_Activum.Models
{
    public class Customer
    {
        public string CustomerId { get; set; } = Guid.NewGuid().ToString().Substring(0, 5);
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PersonalNumber { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string? FullName => $"{FirstName} {LastName}";
    }
}
