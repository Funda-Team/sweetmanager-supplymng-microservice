using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SupplyMngService.Domain.Model.Aggregates;
using SupplyMngService.Domain.Model.Entities;

namespace SupplyMngService.Shared.Infrastructure.Persistence.EFC.Configuration;

public partial class SupplymngContext : DbContext
{
    public SupplymngContext()
    {
    }

    public SupplymngContext(DbContextOptions<SupplymngContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Supply> Supplies { get; set; }

    public virtual DbSet<SupplyRequest> SupplyRequests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=supplymng;user=root;password=password;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("supplies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HotelsId).HasColumnName("hotels_id");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasColumnName("price");
            entity.Property(e => e.ProvidersId).HasColumnName("providers_id");
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .HasColumnName("state");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<SupplyRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("supply_requests");

            entity.HasIndex(e => e.SuppliesId, "supplies_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(10)
                .HasColumnName("amount");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.PaymentOwnersId).HasColumnName("payment_owners_id");
            entity.Property(e => e.SuppliesId).HasColumnName("supplies_id");

            entity.HasOne(d => d.Supplies).WithMany(p => p.SupplyRequests)
                .HasForeignKey(d => d.SuppliesId)
                .HasConstraintName("supply_requests_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
