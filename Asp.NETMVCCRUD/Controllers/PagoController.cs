using BL;
using CrystalDecisions.CrystalReports.Engine;
using ET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.NETMVCCRUD.Controllers
{
    public class PagoController : Controller
    {
        //
        // GET: /Pago/
        public PagoBL Pago = new PagoBL();
        private CursoPosgradoBL curso = new CursoPosgradoBL();
        private CuotaBL cuotas = new CuotaBL();
        private AlumnoBL alumnos = new AlumnoBL();
        private ControlCuotaBL control = new ControlCuotaBL();
        //C:\Users\JLIMACHI\Downloads\Fisiandroide-proyectoposgrado-6e48bc8cd3cc\Fisiandroide-proyectoposgrado-6e48b\Asp.NETMVCCRUD\Controllers\PagoController.cs
        // GET: /Pago/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {

            var usuList = Pago.ObtenerPagos();

            return Json(new { data = usuList }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            ViewBag.listacursos = new SelectList(this.curso.ObtenerCursoPosgrados(), "IdCursoPosgrado", "NombreCursoPosgrado");
            ViewBag.alumnos = new SelectList(this.alumnos.ObtenerAlumnos(), "IdAlumno", "NombreCompleto");
            ViewBag.controlCuota = new SelectList(this.control.ObtenerControlCuotas(), "IdControlCuota", "Matricula");

            if (id == 0)
                return View(new Pago());
            else
            {
                
                    return View(this.Pago.ObtenerPagoPorCodigoBL(id.ToString()));
               
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Pago concepto)
        {

            concepto.FechaRegistro = DateTime.Today;
            concepto.FechaPago = DateTime.Today;
            concepto.UsuarioRegistro = "admin";
            if (concepto.IdPago == 0)
            {
               
                bool flag = this.Pago.GuardarPago(concepto);
                return Json(new { success = true, message = "Guardado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
               
                bool flag = this.Pago.GuardarPago(concepto);
                return Json(new { success = true, message = "Actualizado Correctamente" }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpPost]
        public ActionResult Delete(int id)
        {


            if (this.Pago.EliminarPago(id.ToString()))
            {
                return Json(new { success = true, message = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = "No se pude Eliminar, Error Consulte con el Administrador" }, JsonRequestBehavior.AllowGet);
            }

        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetDataConcepto(string variable)
        {

            var lista = this.Pago.ObtenerPagoPorNroConceptoBL(variable);
            return this.Json(lista, JsonRequestBehavior.AllowGet);
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetDataConceptoById(string id)
        {
            var item = this.Pago.ObtenerPagoPorCodigoBL(id);
            return this.Json(item, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GenerarReporte(string id)
        {

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reporte"), "crReporteAlumno.rpt"));
            rd.SetParameterValue("@IdAlumno",19);
            rd.SetParameterValue("@IdCursoPosgrado", 6);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            return null;

        }
    }
}