using System;
using System.Collections.Generic;

namespace Proj1.Models
{
    public partial class BuildingType
    {
        public BuildingType()
        {
            Buildings = new HashSet<Building>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ConnectionTypeId { get; set; }

        public virtual ElectricityConnectionType ConnectionType { get; set; } = null!;
        public virtual ICollection<Building> Buildings { get; set; }
    }
}
