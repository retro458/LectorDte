using System;
using System.Collections.Generic;
using LectorDte.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LectorDte.API.Data;

public partial class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClasificacionProveedor> ClasificacionProveedors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClasificacionProveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clasific__3214EC0790C0304C");

            entity.ToTable("ClasificacionProveedor");

            entity.HasIndex(e => new { e.NitEmpresa, e.NitProveedor }, "UQ_CP_Empresa_Proveedor").IsUnique();

            entity.Property(e => e.FechaActualizacion).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.NitEmpresa)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NitProveedor)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NombreProveedor).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
