using System;
using System.Collections.Generic;

namespace Proj1.Models
{
    public partial class Bill
    {
        public int Id { get; set; }
        public int? MeterId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime DueDate { get; set; }
        public int TotalUnits { get; set; }
        public double PayableAmount { get; set; }
        public byte IsPayed { get; set; }
        public DateTime? PaymentDate { get; set; }
        public double? FineAmount { get; set; }

        public virtual Meter? Meter { get; set; }
    }
}
