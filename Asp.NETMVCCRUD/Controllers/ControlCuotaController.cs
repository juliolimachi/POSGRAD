using BL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.NETMVCCRUD.Controllers
{
    public class ControlCuotaController : Controller
    {
        //
        // GET: /ControlCuota/

        public ControlCuotaBL ControlCuota = new ControlCuotaBL();
        private CursoPosgradoBL curso = new CursoPosgradoBL();
        private CuotaBL cuota = new CuotaBL();
        //
        // GET: /ControlCuota/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {


            var usuList = ControlCuota.ObtenerControlCuotas();
            return Json(new { data = usuList }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            ViewBag.listacursos = new SelectList(this.curso.ObtenerCursoPosgrados(), "IdCursoPosgrado", "NombreCursoPosgrado");
            ViewBag.cuotas = new SelectList(this.cuota.ObtenerCuotas(), "IdCuota", "Descripcion");
            
            if (id == 0)
                return View(new ControlCuota());
            else
            {
                
                    return View(this.ControlCuota.ObtenerControlCuotaPorCodigoBL(id.ToString()));
             
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(ControlCuota concepto)
        {
            concepto.FechaCreacion = DateTime.Today;
            concepto.FechaVencimiento = DateTime.Today;
            concepto.FlagFinal = 1;

       
            if (concepto.IdControlCuota == 0)
            {
               
                bool flag = this.ControlCuota.GuardarControlCuota(concepto);
                return Json(new { success = true, message = "Guardado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
               // concepto.FechaCreacion = DateTime.Today;
                bool flag = this.ControlCuota.GuardarControlCuota(concepto);
                return Json(new { success = true, message = "Actualizado Correctamente" }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpPost]
        public ActionResult Delete(int id)
        {


            if (this.ControlCuota.EliminarControlCuota(id.ToString()))
            {
                return Json(new { success = true, message = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = "Ocurrio un Error" }, JsonRequestBehavior.AllowGet);
            }

        }

  


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetDataConceptoById(string id)
        {
            var item = this.ControlCuota.ObtenerControlCuotaPorCodigoBL(id);
            return this.Json(item, JsonRequestBehavior.AllowGet);
        }

	}
}