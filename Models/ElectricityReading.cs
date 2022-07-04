using System;
using System.Collections.Generic;

namespace Proj1.Models
{
    public partial class ElectricityReading
    {
        public int Id { get; set; }
        public int? MeterId { get; set; }
        public DateTime Day { get; set; }
        public int? H1 { get; set; }
        public int? H2 { get; set; }
        public int? H3 { get; set; }
        public int? H4 { get; set; }
        public int? H5 { get; set; }
        public int? H6 { get; set; }
        public int? H7 { get; set; }
        public int? H8 { get; set; }
        public int? H9 { get; set; }
        public int? H10 { get; set; }
        public int? H11 { get; set; }
        public int? H12 { get; set; }
        public int? H13 { get; set; }
        public int? H14 { get; set; }
        public int? H15 { get; set; }
        public int? H16 { get; set; }
        public int? H17 { get; set; }
        public int? H18 { get; set; }
        public int? H19 { get; set; }
        public int? H20 { get; set; }
        public int? H21 { get; set; }
        public int? H22 { get; set; }
        public int? H23 { get; set; }
        public int? H24 { get; set; }
        public int TotalUnits { get; set; }

        public virtual Meter? Meter { get; set; }
    }
}
