
namespace ServicioMilitarMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAMPANIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAMPANIA()
        {
            this.SOLDADO = new HashSet<SOLDADO>();
        }
    
        public int numeroCampania { get; set; }
        public string actividad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOLDADO> SOLDADO { get; set; }
    }
}
