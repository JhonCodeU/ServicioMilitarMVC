using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicioMilitarMVC.Models;
using ServicioMilitarMVC.Models.View_Models;

namespace ServicioMilitarMVC.Controllers
{
    public class SoldadoController : Controller
    {
        // GET: Soldado
        public ActionResult Index()
        {
            List<ListSoldadoViewModels> lista;
            using (servicioMilitarEntities db = new servicioMilitarEntities())
            {
                lista = (from buscar in db.SOLDADO
                           select new ListSoldadoViewModels
                           {
                               codigoSoldado = buscar.codigoSoldado,
                               nombre = buscar.nombre,
                               apellido = buscar.apellido,
                               grado = buscar.grado,
                               codigoCuerpo = buscar.codigocuerpo,
                               numeroCapania = buscar.numeroCampania,
                               codigoCuartel = buscar.codigoCuartel
                           }).ToList();
            }

                return View(lista);
        }
    }
}