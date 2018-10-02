using ET;
using BL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.NETMVCCRUD.Controllers
{
    public class CursoPosgradoController : Controller
    {
        private CursoPosgradoBL CursoPosgradoBL = new CursoPosgradoBL();
        private ConceptoPagoBL conceptoBL = new ConceptoPagoBL();
        private EstadoBL estado = new EstadoBL();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            
                var cursoList = this.CursoPosgradoBL.ObtenerCursoPosgrados();
                return Json(new { data = cursoList }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            ViewBag.concepto = new SelectList(this.conceptoBL.ObtenerConceptoPagos(), "IdConceptoPago", "NroConcepto");
            ViewBag.estado = new SelectList(this.estado.ObtenerEstados(), "IdEstado", "Descripcion");
            if (id == 0)
                return View(new CursoPosgrado());
            else
            {

                var cursoList = this.CursoPosgradoBL.ObtenerCursoPosgradoPorCodigoBL(id.ToString());
                return View(cursoList);

            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(CursoPosgrado curso)
        {

            curso.FechaCreacion = DateTime.Today;
           
            curso.UserCreacion = "ADMIN";
            if (curso.IdCursoPosgrado == 0)
            {

                bool flag = CursoPosgradoBL.GuardarCursoPosgrado(curso);


                return Json(new { success = true, message = "Guardado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                bool flag = CursoPosgradoBL.GuardarCursoPosgrado(curso);
                return Json(new { success = true, message = "Actualizado Correctamente" }, JsonRequestBehavior.AllowGet);
            }


        }




        [HttpPost]
        public ActionResult Delete(int id)
        {



            if (this.CursoPosgradoBL.EliminarCursoPosgrado(id.ToString()))
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