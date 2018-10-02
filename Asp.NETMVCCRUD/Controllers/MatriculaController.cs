using BL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.NETMVCCRUD.Controllers
{
    public class MatriculaController : Controller
    {
        public MatriculaBL MatriculaBL = new MatriculaBL();
        //
        // GET: /Matricula/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {

            var usuList = MatriculaBL.ObtenerMatriculas();

            return Json(new { data = usuList }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Matricula());
            else
            {

                return View(this.MatriculaBL.ObtenerMatriculaPorCodigoBL(id.ToString()));

            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Matricula Matricula)
        {



            if (Matricula.Id_Matricula == 0)
            {

                bool flag = this.MatriculaBL.RegistrarMatriculaBL(Matricula);
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                bool flag = this.MatriculaBL.RegistrarMatriculaBL(Matricula);
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpPost]
        public ActionResult Delete(int id)
        {


            if (this.MatriculaBL.EliminarMatricula(id.ToString()))
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

            var lista = this.MatriculaBL.ObtenerMatriculaPorCodigoBL(variable);
            return this.Json(lista, JsonRequestBehavior.AllowGet);
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetDataConceptoById(string id)
        {
            var item = this.MatriculaBL.ObtenerMatriculaPorCodigoBL(id);
            return this.Json(item, JsonRequestBehavior.AllowGet);
        }
	}
}