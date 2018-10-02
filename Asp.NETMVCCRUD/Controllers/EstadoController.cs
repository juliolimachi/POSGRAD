using BL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.NETMVCCRUD.Controllers
{
    public class EstadoController : Controller
    {
        //
        // GET: /Estado/
        public EstadoBL estado = new EstadoBL();
        //
        // GET: /Estado/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {

            var usuList = estado.ObtenerEstados();

            return Json(new { data = usuList }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Estado());
            else
            {

                return View(this.estado.ObtenerEstadoPorCodigoBL(id.ToString()));
               
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Estado concepto)
        {



            if (concepto.IdEstado == 0)
            {

                bool flag = this.estado.GuardarEstado(concepto);
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                bool flag = this.estado.GuardarEstado(concepto);
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpPost]
        public ActionResult Delete(int id)
        {


            if (this.estado.EliminarEstado(id.ToString()))
            {
                return Json(new { success = true, message = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = "Error Successfully" }, JsonRequestBehavior.AllowGet);
            }

        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetDataConcepto(string variable)
        {

            var lista = this.estado.ObtenerEstadoPorNroConceptoBL(variable);
            return this.Json(lista, JsonRequestBehavior.AllowGet);
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetDataConceptoById(string id)
        {
            var item = this.estado.ObtenerEstadoPorCodigoBL(id);
            return this.Json(item, JsonRequestBehavior.AllowGet);
        }

	}
}