using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioMilitarMVC.Models.View_Models
{
    public class ListSoldadoViewModels
    {
        public int codigoSoldado { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String grado { get; set; }
        public int codigoCuerpo { get; set; }
        public int numeroCapania { get; set; }
        public int codigoCuartel { get; set; }


    }
}