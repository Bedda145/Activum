using System;
using System.Collections.Generic;
using System.Text;

namespace PRG1_MAUI_ERP_Activum.Models
{
    public class Insurance
    {
        public string InsuranceId { get; set; } = Guid.NewGuid().ToString().Substring(0, 8);
        public string? InsuranceType { get; set; }
        public double Premium { get; set; }
        public string? Status { get; set; }
        public DateTime StartDate { get; set; }
        public string? CustomerId { get; set; }

    }
}
