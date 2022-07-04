using System;
using System.Collections.Generic;

namespace Proj1.Models
{
    public partial class Slab
    {
        public int Id { get; set; }
        public int ConnectionTypeId { get; set; }
        public int FromUnit { get; set; }
        public int ToUnit { get; set; }
        public double Rate { get; set; }

        public virtual ElectricityConnectionType ConnectionType { get; set; } = null!;
    }
}
