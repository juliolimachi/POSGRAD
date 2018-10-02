using BL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.NETMVCCRUD.Controllers
{
    public class CuotaController : Controller
    {
        // GET: Couta
        public CuotaBL Cuota = new CuotaBL();
        //
        // GET: /Cuota/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {

            var usuList = Cuota.ObtenerCuotas();

            return Json(new { data = usuList }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Cuota());
            else
            {
                
                    return View(this.Cuota.ObtenerCuotaPorCodigoBL(id.ToString()));
               
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Cuota cuota)
        {



            if (cuota.IdCuota == 0)
            {
                
                bool flag = this.Cuota.GuardarCuota(cuota);
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                
                bool flag = this.Cuota.GuardarCuota(cuota);
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpPost]
        public ActionResult Delete(int id)
        {


            if (this.Cuota.EliminarCuota(id.ToString()))
            {
                return Json(new { success = true, message = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = "Error Successfully" }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}