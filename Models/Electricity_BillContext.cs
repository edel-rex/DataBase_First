using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proj1.Models
{
    public partial class Electricity_BillContext : DbContext
    {
        public Electricity_BillContext()
        {
        }

        public Electricity_BillContext(DbContextOptions<Electricity_BillContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<BuildingType> BuildingTypes { get; set; } = null!;
        public virtual DbSet<ElectricityConnectionType> ElectricityConnectionTypes { get; set; } = null!;
        public virtual DbSet<ElectricityReading> ElectricityReadings { get; set; } = null!;
        public virtual DbSet<Meter> Meters { get; set; } = null!;
        public virtual DbSet<Slab> Slabs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\;Database=Electricity_Bill;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("bill");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DueDate)
                    .HasColumnType("date")
                    .HasColumnName("due_date");

                entity.Property(e => e.FineAmount).HasColumnName("fine_amount");

                entity.Property(e => e.IsPayed).HasColumnName("is_payed");

                entity.Property(e => e.MeterId).HasColumnName("meter_id");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.PayableAmount).HasColumnName("Payable_amount");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("Payment_Date");

                entity.Property(e => e.TotalUnits).HasColumnName("total_units");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Meter)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.MeterId)
                    .HasConstraintName("FK__bill__meter_id__534D60F1");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("building");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.BuildingTypeId).HasColumnName("building_type_id");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("contact_number");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email_address");

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("owner_name");

                entity.HasOne(d => d.BuildingType)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.BuildingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__building__buildi__4AB81AF0");
            });

            modelBuilder.Entity<BuildingType>(entity =>
            {
                entity.ToTable("building_type");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ConnectionTypeId).HasColumnName("connection_type_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.ConnectionType)
                    .WithMany(p => p.BuildingTypes)
                    .HasForeignKey(d => d.ConnectionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__building___conne__3C69FB99");
            });

            modelBuilder.Entity<ElectricityConnectionType>(entity =>
            {
                entity.ToTable("electricity_connection_type");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ConnectionName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("connection_name");
            });

            modelBuilder.Entity<ElectricityReading>(entity =>
            {
                entity.ToTable("electricity_reading");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Day)
                    .HasColumnType("date")
                    .HasColumnName("day");

                entity.Property(e => e.H1).HasColumnName("h1");

                entity.Property(e => e.H10).HasColumnName("h10");

                entity.Property(e => e.H11).HasColumnName("h11");

                entity.Property(e => e.H12).HasColumnName("h12");

                entity.Property(e => e.H13).HasColumnName("h13");

                entity.Property(e => e.H14).HasColumnName("h14");

                entity.Property(e => e.H15).HasColumnName("h15");

                entity.Property(e => e.H16).HasColumnName("h16");

                entity.Property(e => e.H17).HasColumnName("h17");

                entity.Property(e => e.H18).HasColumnName("h18");

                entity.Property(e => e.H19).HasColumnName("h19");

                entity.Property(e => e.H2).HasColumnName("h2");

                entity.Property(e => e.H20).HasColumnName("h20");

                entity.Property(e => e.H21).HasColumnName("h21");

                entity.Property(e => e.H22).HasColumnName("h22");

                entity.Property(e => e.H23).HasColumnName("h23");

                entity.Property(e => e.H24).HasColumnName("h24");

                entity.Property(e => e.H3).HasColumnName("h3");

                entity.Property(e => e.H4).HasColumnName("h4");

                entity.Property(e => e.H5).HasColumnName("h5");

                entity.Property(e => e.H6).HasColumnName("h6");

                entity.Property(e => e.H7).HasColumnName("h7");

                entity.Property(e => e.H8).HasColumnName("h8");

                entity.Property(e => e.H9).HasColumnName("h9");

                entity.Property(e => e.MeterId).HasColumnName("meter_id");

                entity.Property(e => e.TotalUnits).HasColumnName("total_units");

                entity.HasOne(d => d.Meter)
                    .WithMany(p => p.ElectricityReadings)
                    .HasForeignKey(d => d.MeterId)
                    .HasConstraintName("FK__electrici__meter__5070F446");
            });

            modelBuilder.Entity<Meter>(entity =>
            {
                entity.ToTable("meter");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.MeterNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("meter_number");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Meters)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("FK__meter__building___4D94879B");
            });

            modelBuilder.Entity<Slab>(entity =>
            {
                entity.ToTable("slab");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ConnectionTypeId).HasColumnName("connection_type_id");

                entity.Property(e => e.FromUnit).HasColumnName("from_unit");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.ToUnit).HasColumnName("to_unit");

                entity.HasOne(d => d.ConnectionType)
                    .WithMany(p => p.Slabs)
                    .HasForeignKey(d => d.ConnectionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__slab__connection__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
