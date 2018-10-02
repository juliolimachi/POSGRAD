
using BL;
using ET;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.NETMVCCRUD.Controllers
{
    public class ConceptoPagoController : Controller
    {
        public ConceptoPagoBL conceptopago = new ConceptoPagoBL();
        //
        // GET: /ConceptoPago/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {

            var usuList = conceptopago.ObtenerConceptoPagos();
            return Json(new { data = usuList }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new ConceptoPago());
            else
            {
                
                    return View(this.conceptopago.ObtenerConceptoPagoPorCodigoBL(id.ToString()));
               
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(ConceptoPago concepto)
        {



            if (concepto.IdConceptoPago == 0)
            {
                concepto.FechaCreacion = DateTime.Today;
                bool flag = this.conceptopago.GuardarConceptoPago(concepto);
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                concepto.FechaCreacion = DateTime.Today;
                bool flag = this.conceptopago.GuardarConceptoPago(concepto);
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpPost]
        public ActionResult Delete(int id)
        {


            if (this.conceptopago.EliminarConceptoPago(id.ToString()))
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

            var lista = this.conceptopago.ObtenerConceptoPagoPorNroConceptoBL(variable);
            return this.Json(lista, JsonRequestBehavior.AllowGet);
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetDataConceptoById(string id)
        {
            var item = this.conceptopago.ObtenerConceptoPagoPorCodigoBL(id);
            return this.Json(item, JsonRequestBehavior.AllowGet);
        }
	}
}