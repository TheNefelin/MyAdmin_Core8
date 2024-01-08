using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Server_WebAPI.Models;

public partial class DB_Context : DbContext
{
    public DB_Context()
    {
    }

    public DB_Context(DbContextOptions<DB_Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<PfLink> PfLinks { get; set; }

    public virtual DbSet<PfLinkGrp> PfLinkGrps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departam__3213E83F81FF1212");

            entity.ToTable("departamento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__empleado__3213E83F6DBC7784");

            entity.ToTable("empleado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaContrato)
                .HasColumnType("datetime")
                .HasColumnName("fecha_contrato");
            entity.Property(e => e.IdDepto).HasColumnName("id_depto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Sueldo).HasColumnName("sueldo");

            entity.HasOne(d => d.IdDeptoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdDepto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__empleado__id_dep__4316F928");
        });

        modelBuilder.Entity<PfLink>(entity =>
        {
            entity.HasKey(e => e.IdLink).HasName("PK__pf_link__99847A44166AE998");

            entity.ToTable("pf_link");

            entity.Property(e => e.IdLink).HasColumnName("id_link");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdLinkGrp).HasColumnName("id_link_grp");
            entity.Property(e => e.Linkurl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("linkurl");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdLinkGrpNavigation).WithMany(p => p.PfLinks)
                .HasForeignKey(d => d.IdLinkGrp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pf_link__id_link__47DBAE45");
        });

        modelBuilder.Entity<PfLinkGrp>(entity =>
        {
            entity.HasKey(e => e.IdLinkGrp).HasName("PK__pf_link___08BADBB13B4BFFC1");

            entity.ToTable("pf_link_grp");

            entity.Property(e => e.IdLinkGrp).HasColumnName("id_link_grp");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
