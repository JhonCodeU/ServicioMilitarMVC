

namespace ServicioMilitarMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CUERPO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUERPO()
        {
            this.SOLDADO = new HashSet<SOLDADO>();
        }
    
        public int codigocuerpo { get; set; }
        public string denominacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOLDADO> SOLDADO { get; set; }
    }
}
