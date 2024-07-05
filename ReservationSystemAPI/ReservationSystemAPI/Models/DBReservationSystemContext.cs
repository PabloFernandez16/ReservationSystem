using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ReservationSystemAPI.Models
{
    public partial class DBReservationSystemContext : DbContext
    {
        public DBReservationSystemContext()
        {
        }

        public DBReservationSystemContext(DbContextOptions<DBReservationSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Guide> Guides { get; set; } = null!;
        public virtual DbSet<Lenguage> Lenguages { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<TourType> TourTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guide>(entity =>
            {
                entity.ToTable("Guide");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GuideLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GuideName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LenguagesId).HasColumnName("LenguagesID");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lenguages)
                    .WithMany(p => p.Guides)
                    .HasForeignKey(d => d.LenguagesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Guide__Lenguages__3C69FB99");
            });

            modelBuilder.Entity<Lenguage>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LenguageDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActivityDate).HasColumnType("date");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DropOffLocation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GuideId).HasColumnName("GuideID");

                entity.Property(e => e.PickUpLocation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SellerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Total).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.TotalPax).HasColumnName("TotalPAX");

                entity.Property(e => e.TourTypeId).HasColumnName("TourTypeID");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(14, 2)");

                entity.HasOne(d => d.Guide)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.GuideId)
                    .HasConstraintName("FK__Reservati__Guide__403A8C7D");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reservati__Suppl__412EB0B6");

                entity.HasOne(d => d.TourType)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.TourTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reservati__TourT__3F466844");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TourType>(entity =>
            {
                entity.ToTable("TourType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Price).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.TourDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TourName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
