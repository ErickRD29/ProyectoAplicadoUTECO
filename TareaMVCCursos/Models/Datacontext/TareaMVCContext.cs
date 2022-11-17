
using Microsoft.EntityFrameworkCore;
namespace TareaMVCCursos.Models.Datacontext
{
    public class TareaMVCContext : DbContext, MVCDataContext
    {
        public TareaMVCContext(DbContextOptions options) : base(options)
        {

        }

        #region Tablas
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public DbSet<Publicacione> Publicaciones { get; set; }

        public DbSet<PublicacionesModalidade> PublicacionesModalidades { get; set; }

        public DbSet<PublicacionesTipo> PublicacionesTipos { get; set; }

        public DbSet<Solicitude> Solicitudes { get; set; }

        public DbSet<SolicitudesEstado> SolicitudesEstados { get; set; }
        #endregion

        #region Funciones
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        #endregion
    }

    public interface MVCDataContext
    {
        #region Tablas
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Publicacione> Publicaciones { get; set; }

        public DbSet<PublicacionesModalidade> PublicacionesModalidades { get; set; }

        public DbSet<PublicacionesTipo> PublicacionesTipos { get; set; }

        public DbSet<Solicitude> Solicitudes { get; set; }

        public DbSet<SolicitudesEstado> SolicitudesEstados { get; set; }
        #endregion

        #region Funciones
        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        #endregion
    }
}
