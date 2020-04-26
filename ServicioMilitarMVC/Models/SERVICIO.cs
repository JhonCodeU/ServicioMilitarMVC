
namespace ServicioMilitarMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SERVICIO
    {
        public int numeroServicio { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> codigoSoldado { get; set; }
    
        public virtual SOLDADO SOLDADO { get; set; }
    }
}
