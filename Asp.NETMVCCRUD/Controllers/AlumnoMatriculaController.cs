using BL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ET;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.NETMVCCRUD.Controllers
{

  
    public class AlumnoMatriculaController : Controller
    {
        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AATEConnectionString"].ConnectionString;

        // GET: AlumnoMatricula
        public AlumnoMatriculaBL AlumnoMatriculaBl = new AlumnoMatriculaBL();
        private CursoPosgradoBL cursoBL = new CursoPosgradoBL();
        //
        // GET: /AlumnoMatricula/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {

            var usuList = AlumnoMatriculaBl.ObtenerAlumnoMatriculas();

            return Json(new { data = usuList }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            ViewBag.cursos = new SelectList(this.cursoBL.ObtenerCursoPosgrados(), "IdCursoPosgrado", "NombreCursoPosgrado");


            if (id == 0)
                return View(new AlumnoMatricula());
            else
            {

                return View(this.AlumnoMatriculaBl.ObtenerAlumnoMatriculaPorCodigoBL(id.ToString()));

            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(AlumnoMatricula concepto)
        {



            if (concepto.IdAlumnoMatricula == 0)
            {

                bool flag = AlumnoMatriculaBl.RegistrarAlumnoMatriculaBL(concepto);

                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                bool flag = this.AlumnoMatriculaBl.ActualizarAlumnoMatriculaBL(concepto);
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpPost]
        public ActionResult Delete(int id)
        {


            if (AlumnoMatriculaBl.EliminarAlumnoMatricula(id.ToString()))
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

           
           var AlumnoMatricula = AlumnoMatriculaBl.ObtenerAlumnoMatriculaPorCodigoBL(id.ToString());

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reporte"), "crReportePagoConsolidado.rpt"));
            rd.SetParameterValue("@CodigoAlumno", AlumnoMatricula.CodigoAlumno);
            //rd.SetParameterValue("@IdCursoPosgrado", AlumnoMatricula.Id);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            rd.SetDatabaseLogon("sa", "F4br1c4*4t3", "13.59.152.82", "POST_PRUEBA");

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            rd.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("~/Reporte/AlumnoMatricula.pdf"));


            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf");

        }



        public ActionResult GenerarDetalle(string id)
        {

            var usuList = AlumnoMatriculaBl.ObtenerDetalleAlumnoMatriculaPorCodigoBL(id);

            return Json(new { data = usuList }, JsonRequestBehavior.AllowGet);
        }




    }
}