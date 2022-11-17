
using Microsoft.EntityFrameworkCore;
using TareaMVCCursos.Models;

namespace TareaMVCCursos.Models { 

    public partial class TareaMvccursosContext : DbContext
    {
        public TareaMvccursosContext()
        {
        }

        public TareaMvccursosContext(DbContextOptions<TareaMvccursosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Personas { get; set; }

        public virtual DbSet<Publicacione> Publicaciones { get; set; }

        public virtual DbSet<PublicacionesModalidade> PublicacionesModalidades { get; set; }

        public virtual DbSet<PublicacionesTipo> PublicacionesTipos { get; set; }

        public virtual DbSet<Solicitude> Solicitudes { get; set; }

        public virtual DbSet<SolicitudesEstado> SolicitudesEstados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=DESKTOP-DFA2A6U;Database=TareaMVCCursos;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.AreaDeFormacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Cedula)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Formacionacademica)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Telefono)
                    .HasMaxLength(14)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Publicacione>(entity =>
            {
                entity.HasKey(e => e.IdPublicacion);

                entity.Property(e => e.Costo).HasColumnType("smallmoney");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.FechaExpiracion).HasColumnType("datetime");
                entity.Property(e => e.FechaInicio).HasColumnType("datetime");
                entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UrlImagen)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("urlImagen");

                entity.HasOne(d => d.IdModalidadNavigation).WithMany(p => p.Publicaciones)
                    .HasForeignKey(d => d.IdModalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publicaciones_PublicacionesModalidades");

                entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Publicaciones)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publicaciones_PublicacionesTipos");
            });

            modelBuilder.Entity<PublicacionesModalidade>(entity =>
            {
                entity.HasKey(e => e.IdModalidad);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PublicacionesTipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo);

                entity.Property(e => e.Tipo).HasMaxLength(50);
            });

            modelBuilder.Entity<Solicitude>(entity =>
            {
                entity.HasKey(e => e.IdSolicitud);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solicitudes_SolicitudesEstados");

                entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solicitudes_Personas");

                entity.HasOne(d => d.IdPublicacionNavigation).WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.IdPublicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solicitudes_Publicaciones");
            });

            modelBuilder.Entity<SolicitudesEstado>(entity =>
            {
                entity.HasKey(e => e.IdEstado);

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
