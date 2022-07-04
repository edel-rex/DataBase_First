using System;
using System.Collections.Generic;

namespace Proj1.Models
{
    public partial class Meter
    {
        public Meter()
        {
            Bills = new HashSet<Bill>();
            ElectricityReadings = new HashSet<ElectricityReading>();
        }

        public int Id { get; set; }
        public string MeterNumber { get; set; } = null!;
        public int? BuildingId { get; set; }

        public virtual Building? Building { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<ElectricityReading> ElectricityReadings { get; set; }
    }
}
