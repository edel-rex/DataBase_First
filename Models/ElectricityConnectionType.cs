using System;
using System.Collections.Generic;

namespace Proj1.Models
{
    public partial class ElectricityConnectionType
    {
        public ElectricityConnectionType()
        {
            BuildingTypes = new HashSet<BuildingType>();
            Slabs = new HashSet<Slab>();
        }

        public int Id { get; set; }
        public string ConnectionName { get; set; } = null!;

        public virtual ICollection<BuildingType> BuildingTypes { get; set; }
        public virtual ICollection<Slab> Slabs { get; set; }
    }
}
