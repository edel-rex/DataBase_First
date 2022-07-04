using System;
using Microsoft.EntityFrameworkCore;
using Proj1.Models;

namespace Proj1.Models
{


    public partial class Electricity_BillContext : DbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

        }
    }
}
