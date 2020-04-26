
namespace ServicioMilitarMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class servicioMilitarEntities : DbContext
    {
        public servicioMilitarEntities()
            : base("name=servicioMilitarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CAMPANIA> CAMPANIA { get; set; }
        public virtual DbSet<CUARTEL> CUARTEL { get; set; }
        public virtual DbSet<CUERPO> CUERPO { get; set; }
        public virtual DbSet<SERVICIO> SERVICIO { get; set; }
        public virtual DbSet<SOLDADO> SOLDADO { get; set; }
    }
}
