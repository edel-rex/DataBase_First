using System;
using System.Collections.Generic;

namespace Proj1.Models
{
    public partial class Building
    {
        public Building()
        {
            Meters = new HashSet<Meter>();
        }

        public int Id { get; set; }
        public string OwnerName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int BuildingTypeId { get; set; }
        public string ContactNumber { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;

        public virtual BuildingType BuildingType { get; set; } = null!;
        public virtual ICollection<Meter> Meters { get; set; }
    }
}
