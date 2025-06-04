using System;
using System.Collections.Generic;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
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

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    public virtual DbSet<Supply> Supplies { get; set; }

    public virtual DbSet<SuppliesRequest> SupplyRequests { get; set; }
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

        modelBuilder.Entity<SuppliesRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("supply_requests");

            entity.HasIndex(e => e.SuppliesId, "supplies_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(10)
                .HasColumnName("amount");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.PaymentOwnerId).HasColumnName("payment_owners_id");
            entity.Property(e => e.SuppliesId).HasColumnName("supplies_id");

            entity.HasOne(d => d.Supplies).WithMany(p => p.SupplyRequests)
                .HasForeignKey(d => d.SuppliesId)
                .HasConstraintName("supply_requests_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
