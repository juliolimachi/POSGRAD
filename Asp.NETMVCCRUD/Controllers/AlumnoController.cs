
using BL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ET;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.NETMVCCRUD.Controllers
{
    public class AlumnoController : Controller
    {
        public AlumnoBL alumnoBl = new AlumnoBL();
        private CursoPosgradoBL cursoBL = new CursoPosgradoBL();
        //
        // GET: /Alumno/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {

            var usuList = alumnoBl.ObtenerAlumnos();

            return Json(new { data = usuList }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            ViewBag.cursos = new SelectList(this.cursoBL.ObtenerCursoPosgrados(),"IdCursoPosgrado","NombreCursoPosgrado" );


            if (id == 0)
                return View(new Alumno());
            else
            {
               
                    return View(this.alumnoBl.ObtenerAlumnoPorCodigoBL(id.ToString()));
               
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Alumno concepto)
        {



            if (concepto.IdAlumno == 0)
            {
               
                bool flag = alumnoBl.RegistrarAlumnoBL(concepto);

                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                bool flag = this.alumnoBl.ActualizarAlumnoBL(concepto);
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpPost]
        public ActionResult Delete(int id)
        {


            if (alumnoBl.EliminarAlumno(id.ToString()))
            {
                return Json(new { success = true, message = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = "Error Successfully" }, JsonRequestBehavior.AllowGet);
            }

        }



        public ActionResult GenerarReporte(string id)
        {

            var alumno = alumnoBl.ObtenerAlumnoPorCodigoBL(id.ToString());

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reporte"), "crReporteAlumno.rpt"));
            rd.SetParameterValue("@IdAlumno", id);
            rd.SetParameterValue("@IdCursoPosgrado", alumno.IdCursoPosgrado);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            rd.SetDatabaseLogon("sa", "F4br1c4*4t3", "13.59.152.82", "POST_PRUEBA");

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            rd.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("~/Reporte/alumno.pdf"));

          
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf");

        }

        

    }
}