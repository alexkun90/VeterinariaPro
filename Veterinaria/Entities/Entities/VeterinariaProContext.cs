using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

public partial class VeterinariaProContext : DbContext
{
    public VeterinariaProContext()
    {
    }

    public VeterinariaProContext(DbContextOptions<VeterinariaProContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<DesparasitacionesVacuna> DesparasitacionesVacunas { get; set; }

    public virtual DbSet<Mascota> Mascotas { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<Padecimiento> Padecimientos { get; set; }

    public virtual DbSet<Raza> Razas { get; set; }

    public virtual DbSet<TiposMascota> TiposMascotas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ALEX\\SQLEXPRESS;Database=VeterinariaPro;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.CitaId).HasName("PK__Citas__F0E2D9F2A04FC448");

            entity.Property(e => e.CitaId)
                .ValueGeneratedNever()
                .HasColumnName("CitaID");
            entity.Property(e => e.DescripcionCita).IsUnicode(false);
            entity.Property(e => e.Diagnostico).IsUnicode(false);
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.MascotaId).HasColumnName("MascotaID");
            entity.Property(e => e.VeterinarioPrincipalId).HasColumnName("VeterinarioPrincipalID");
            entity.Property(e => e.VeterinarioSecundarioId).HasColumnName("VeterinarioSecundarioID");

            entity.HasOne(d => d.Mascota).WithMany(p => p.Cita)
                .HasForeignKey(d => d.MascotaId)
                .HasConstraintName("FK_Citas_Mascotas");

            entity.HasOne(d => d.VeterinarioPrincipal).WithMany(p => p.CitaVeterinarioPrincipals)
                .HasForeignKey(d => d.VeterinarioPrincipalId)
                .HasConstraintName("FK_Citas_Usuarios_Principal");

            entity.HasOne(d => d.VeterinarioSecundario).WithMany(p => p.CitaVeterinarioSecundarios)
                .HasForeignKey(d => d.VeterinarioSecundarioId)
                .HasConstraintName("FK_Citas_Usuarios_Secundario");
        });

        modelBuilder.Entity<DesparasitacionesVacuna>(entity =>
        {
            entity.HasKey(e => e.CodigoDesparasitacionVacuna).HasName("PK__Desparas__2D9E31E78578F4D0");

            entity.Property(e => e.CodigoDesparasitacionVacuna).ValueGeneratedNever();
            entity.Property(e => e.MascotaId).HasColumnName("MascotaID");
            entity.Property(e => e.Producto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Mascota).WithMany(p => p.DesparasitacionesVacunas)
                .HasForeignKey(d => d.MascotaId)
                .HasConstraintName("FK_DesparasitacionesVacunas_Mascotas");
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.MascotaId).HasName("PK__Mascotas__8DBC411C0F801641");

            entity.Property(e => e.MascotaId)
                .ValueGeneratedNever()
                .HasColumnName("MascotaID");
            entity.Property(e => e.DueñoId).HasColumnName("DueñoID");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NombreMascota)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RazaId).HasColumnName("RazaID");
            entity.Property(e => e.TipoMascotaId).HasColumnName("TipoMascotaID");

            entity.HasOne(d => d.Dueño).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.DueñoId)
                .HasConstraintName("FK_Mascotas_Usuarios");

            entity.HasOne(d => d.Raza).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.RazaId)
                .HasConstraintName("FK_Mascotas_Razas");

            entity.HasOne(d => d.TipoMascota).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.TipoMascotaId)
                .HasConstraintName("FK_Mascotas_TiposMascotas");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.CodigoMedicamento).HasName("PK__Medicame__44FEECE92939E899");

            entity.Property(e => e.CodigoMedicamento).ValueGeneratedNever();
            entity.Property(e => e.CitaId).HasColumnName("CitaID");
            entity.Property(e => e.Dosis)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreMedicamento)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Cita).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.CitaId)
                .HasConstraintName("FK_Medicamentos_Citas");
        });

        modelBuilder.Entity<Padecimiento>(entity =>
        {
            entity.HasKey(e => e.CodigoPadecimiento).HasName("PK__Padecimi__EDA0C7413999FA00");

            entity.Property(e => e.CodigoPadecimiento).ValueGeneratedNever();
            entity.Property(e => e.MascotaId).HasColumnName("MascotaID");
            entity.Property(e => e.NombrePadecimiento)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Mascota).WithMany(p => p.Padecimientos)
                .HasForeignKey(d => d.MascotaId)
                .HasConstraintName("FK_Padecimientos_Mascotas");
        });

        modelBuilder.Entity<Raza>(entity =>
        {
            entity.HasKey(e => e.CodigoRaza).HasName("PK__Razas__2B50068FD69FAA68");

            entity.Property(e => e.CodigoRaza).ValueGeneratedNever();
            entity.Property(e => e.NombreRaza)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TipoMascotaId).HasColumnName("TipoMascotaID");

            entity.HasOne(d => d.TipoMascota).WithMany(p => p.Razas)
                .HasForeignKey(d => d.TipoMascotaId)
                .HasConstraintName("FK_Razas_TiposMascotas");
        });

        modelBuilder.Entity<TiposMascota>(entity =>
        {
            entity.HasKey(e => e.CodigoTipoMascota).HasName("PK__TiposMas__DF59DB92644F3AB3");

            entity.Property(e => e.CodigoTipoMascota).ValueGeneratedNever();
            entity.Property(e => e.NombreTipoMascota)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.CodigoUsuario).HasName("PK__Usuarios__F0C18F584D3F21CA");

            entity.Property(e => e.CodigoUsuario).ValueGeneratedNever();
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EstadoUsuario)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UltimaConexion).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
