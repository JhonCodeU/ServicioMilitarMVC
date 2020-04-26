
namespace ServicioMilitarMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CUARTEL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUARTEL()
        {
            this.SOLDADO = new HashSet<SOLDADO>();
        }
    
        public int codigoCuartel { get; set; }
        public string nombre { get; set; }
        public string ubicacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOLDADO> SOLDADO { get; set; }
    }
}
