

namespace ServicioMilitarMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SOLDADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SOLDADO()
        {
            this.SERVICIO = new HashSet<SERVICIO>();
        }
    
        public int codigoSoldado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string grado { get; set; }
        public int codigocuerpo { get; set; }
        public int numeroCampania { get; set; }
        public int codigoCuartel { get; set; }
    
        public virtual CAMPANIA CAMPANIA { get; set; }
        public virtual CUARTEL CUARTEL { get; set; }
        public virtual CUERPO CUERPO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SERVICIO> SERVICIO { get; set; }
    }
}
