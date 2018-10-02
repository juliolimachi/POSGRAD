using BL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.NETMVCCRUD.Controllers
{
    public class PagoConsolidadoController : Controller
    {
        // GET: PagoConsolidado
        public PagoConsolidadoBL PagoConsolidadoBL = new PagoConsolidadoBL();
        //
        // GET: /PagoConsolidado/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {

            var usuList = PagoConsolidadoBL.ObtenerPagoConsolidados();
            return Json(new { data = usuList }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new PagoConsolidado());
            else
            {

               return View(this.PagoConsolidadoBL.ObtenerPagoConsolidadoPorCodigoBL(id.ToString()));

            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(PagoConsolidado PagoConsolidado)
        {

           

            if (PagoConsolidado.IdPagoConsolidado == 0)
            {
                if (ModelState.IsValid)
                {
                    bool flag = this.PagoConsolidadoBL.RegistrarPagoConsolidadoBL(PagoConsolidado);
                    return Json(new { success = true, message = "Guardado Correcto" }, JsonRequestBehavior.AllowGet);


                }
                else
                {

                    return Json(new { success = true, message = "Guardado Correcto" }, JsonRequestBehavior.AllowGet);


                }

            }
            else
            {

                bool flag = this.PagoConsolidadoBL.RegistrarPagoConsolidadoBL(PagoConsolidado);
                return Json(new { success = true, message = "Actualizado Correctamente" }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpPost]
        public ActionResult Delete(int id)
        {


            if (this.PagoConsolidadoBL.EliminarPagoConsolidado(id.ToString()))
            {
                return Json(new { success = true, message = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = "Error en la operación" }, JsonRequestBehavior.AllowGet);
            }

        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetDataConcepto(string variable)
        {

            var lista = this.PagoConsolidadoBL.ObtenerPagoConsolidadoPorCodigoBL(variable);
            return this.Json(lista, JsonRequestBehavior.AllowGet);

        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetDataConceptoById(string id)
        {
            var item = this.PagoConsolidadoBL.ObtenerPagoConsolidadoPorCodigoBL(id);
            return this.Json(item, JsonRequestBehavior.AllowGet);
        }



    }
}