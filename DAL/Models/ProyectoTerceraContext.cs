using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class ProyectoTerceraContext : DbContext
{
    public ProyectoTerceraContext()
    {
    }

    public ProyectoTerceraContext(DbContextOptions<ProyectoTerceraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acceso> Accesos { get; set; }

    public virtual DbSet<Incidencia> Incidencias { get; set; }

    public virtual DbSet<Solicitude> Solicitudes { get; set; }

    public virtual DbSet<TiposIncidencia> TiposIncidencias { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<Trabajo> Trabajos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=proyectoTercera;Username=postgres;Password=Flash12311");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acceso>(entity =>
        {
            entity.HasKey(e => e.IdAcceso).HasName("accesos_pkey");

            entity.ToTable("accesos", "personal_datos");

            entity.Property(e => e.IdAcceso).HasColumnName("id_acceso");
            entity.Property(e => e.CodigoAcceso)
                .HasMaxLength(255)
                .HasColumnName("codigo_acceso");
            entity.Property(e => e.DescripcionAcceso)
                .HasMaxLength(255)
                .HasColumnName("descripcion_acceso");
        });

        modelBuilder.Entity<Incidencia>(entity =>
        {
            entity.HasKey(e => e.IdIncidencia).HasName("incidencias_pkey");

            entity.ToTable("incidencias", "datos_puros");

            entity.HasIndex(e => e.IdSolicitud, "uk_kfklp89d4p9rjoe481hy97ohn").IsUnique();

            entity.Property(e => e.IdIncidencia).HasColumnName("id_incidencia");
            entity.Property(e => e.CosteIncidencia).HasColumnName("coste_incidencia");
            entity.Property(e => e.DescripcionTecnica)
                .HasMaxLength(255)
                .HasColumnName("descripcion_tecnica");
            entity.Property(e => e.DescripcionUsuario)
                .HasMaxLength(255)
                .HasColumnName("descripcion_usuario");
            entity.Property(e => e.EstadoIncidencia).HasColumnName("estado_incidencia");
            entity.Property(e => e.FechaFin)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.HorasIncidencia).HasColumnName("horas_incidencia");
            entity.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdSolicitudNavigation).WithOne(p => p.Incidencia)
                .HasForeignKey<Incidencia>(d => d.IdSolicitud)
                .HasConstraintName("fkqf7foy3yo5prj3qu6w08sw00w");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Incidencia)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fki03mjcwbaij4ybwn8nw8t820k");
        });

        modelBuilder.Entity<Solicitude>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud).HasName("solicitudes_pkey");

            entity.ToTable("solicitudes", "datos_puros");

            entity.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            entity.Property(e => e.DescripcionSolicitud)
                .HasMaxLength(255)
                .HasColumnName("descripcion_solicitud");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaLimite)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("fecha_limite");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fk80y8yk97k9fc2o45sc9n5f7ok");
        });

        modelBuilder.Entity<TiposIncidencia>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("tipos_incidencias_pkey");

            entity.ToTable("tipos_incidencias", "datos_puros");

            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.DescripcionTipo)
                .HasMaxLength(255)
                .HasColumnName("descripcion_tipo");
            entity.Property(e => e.FechaExpiracion)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("fecha_expiracion");
            entity.Property(e => e.PrecioTipo).HasColumnName("precio_tipo");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.IdToken).HasName("tokens_pkey");

            entity.ToTable("tokens", "personal_datos");

            entity.Property(e => e.IdToken).HasColumnName("id_token");
            entity.Property(e => e.FechaLimite)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("fecha_limite");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Token1)
                .HasMaxLength(255)
                .HasColumnName("token");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fkg6l1d8wdjrbn75r7rltyiqifh");
        });

        modelBuilder.Entity<Trabajo>(entity =>
        {
            entity.HasKey(e => e.IdTrabajo).HasName("trabajos_pkey");

            entity.ToTable("trabajos", "datos_puros");

            entity.Property(e => e.IdTrabajo).HasColumnName("id_trabajo");
            entity.Property(e => e.DescripcionTrabajo)
                .HasMaxLength(255)
                .HasColumnName("descripcion_trabajo");
            entity.Property(e => e.EstadoTrabajo).HasColumnName("estado_trabajo");
            entity.Property(e => e.HorasTrabajo).HasColumnName("horas_trabajo");
            entity.Property(e => e.IdIncidencia).HasColumnName("id_incidencia");
            entity.Property(e => e.IdTipoIncidencia).HasColumnName("id_tipo_incidencia");

            entity.HasOne(d => d.IdIncidenciaNavigation).WithMany(p => p.Trabajos)
                .HasForeignKey(d => d.IdIncidencia)
                .HasConstraintName("fkdmmx9m9ti9aqrfs1yp5ip7v3w");

            entity.HasOne(d => d.IdTipoIncidenciaNavigation).WithMany(p => p.Trabajos)
                .HasForeignKey(d => d.IdTipoIncidencia)
                .HasConstraintName("fki8mym9fc6j8u80hde9ee2ola8");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("usuarios_pkey");

            entity.ToTable("usuarios", "personal_datos");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Alta).HasColumnName("alta");
            entity.Property(e => e.ContraseniaUsuario)
                .HasMaxLength(255)
                .HasColumnName("contrasenia_usuario");
            entity.Property(e => e.CorreoUsuario)
                .HasMaxLength(255)
                .HasColumnName("correo_usuario");
            entity.Property(e => e.FotoUsuario).HasColumnName("foto_usuario");
            entity.Property(e => e.IdAcceso).HasColumnName("id_acceso");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(255)
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.TelefonoUsuario)
                .HasMaxLength(255)
                .HasColumnName("telefono_usuario");

            entity.HasOne(d => d.IdAccesoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdAcceso)
                .HasConstraintName("fk23olhy66uj44w5qgqhk6u3jo5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
