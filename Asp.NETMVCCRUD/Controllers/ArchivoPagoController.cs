using BL;
using ET;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Asp.NETMVCCRUD.Controllers
{
    public class ArchivoPagoController : Controller
    {
        // GET: ArchivoPagoPago



        public static string DB_PATH = @"";
        protected readonly RuleSettings _fileSettings;

        public ArchivoPagoBL ArchivoPagoBl = new ArchivoPagoBL();
        public AlumnoMatriculaBL AlumnoMatriculaBl = new AlumnoMatriculaBL();
        //
        // GET: /ArchivoPago/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {

            var usuList = ArchivoPagoBl.ObtenerArchivoPagos();

            return Json(new { data = usuList }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            if (id == 0)
                return View(new ArchivoPago());
            else
            {

                return View(this.ArchivoPagoBl.ObtenerArchivoPagoPorCodigoBL(id.ToString()));

            }
        }

        [HttpPost]
        public ActionResult Upload()
        {


            string directory = ConfigurationManager.AppSettings["Pagos"];

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                                                            //Use the following properties to get file's name, size and MIMEType
                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;

                //To save file, use SaveAs method

                if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx"))
                {
                    DB_PATH = Path.Combine(directory, fileName);

                    var formato = fileName.Substring(0, 4);
                    var anhio = fileName.Substring(5, 4);
                    var mes = fileName.Substring(10, 2);
                    var NombreArchivo = fileName;


                    ArchivoPago ArchivoPago = new ArchivoPago();

                    ArchivoPago.NombreArchivo = NombreArchivo;
                    ArchivoPago.Formato = formato;
                    ArchivoPago.FechaSubida = DateTime.Today;
                    ArchivoPago.Periodo = anhio + "" + mes;
                    ArchivoPago.EstadoValidacion = 0;
                    ArchivoPago.EstadoArchivo = 1;

                    if (ArchivoPagoBl.ObtenerArchivoPagoPorNombreBL(NombreArchivo) == null)
                    {
                        bool flag = ArchivoPagoBl.RegistrarArchivoPagoBL(ArchivoPago);

                        file.SaveAs(DB_PATH); //File will be saved in application root

                        return Json(new { success = true, message = "Upload Successfully" }, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        return Json(new { success = false, message = "Ya Existe un ArchivoPago con el mismo nombre" }, JsonRequestBehavior.AllowGet);
                    }


                }
                else
                {

                    return Json(new { success = false, message = "Error Successfully" }, JsonRequestBehavior.AllowGet);
                }


            }
            return Json(new { success = false, message = "Update Successfully" }, JsonRequestBehavior.AllowGet);
        }





        [HttpPost]
        public ActionResult UploadProcesar(string id)
        {
            List<PagoConsolidado> items = new List<PagoConsolidado>();


            string directory = ConfigurationManager.AppSettings["Pagos"];

            var NombreArchivo = ArchivoPagoBl.ObtenerArchivoPagoPorCodigoBL(id);
            var path = Path.Combine(directory, NombreArchivo.NombreArchivo);

            using (var instream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            using (var pck = new ExcelPackage(instream))
            {
                var ws = pck.Workbook.Worksheets["F002"];

                if (ws == null)
                {
                    //throw new BusinessExceptions("No se encontro una Hoja Excel con el nombre: [F.211].");
                }

                int rowNumber = 2;
                int i = 0;
           


                while (!string.IsNullOrEmpty(ws.Cells[$"A{rowNumber}"].GetValue<int>().ToString()))
                {
                
                    try
                    {
                        var item = new PagoConsolidado()
                        {

                            NumDeposito = ws.Cells[$"B{rowNumber}"].GetValue<int>(),
                            CodigoAlumno = ws.Cells[$"C{rowNumber}"].GetValue<int>(),
                            Importe = ws.Cells[$"D{rowNumber}"].GetValue<decimal>(),
                            FecharRegistro = ws.Cells[$"E{rowNumber}"].GetValue<DateTime>(),
                            FechaPago = ws.Cells[$"E{rowNumber}"].GetValue<DateTime>(),
                            CodigoMatricula = ws.Cells[$"F{rowNumber}"].GetValue<int>(),

                            concepto = new ConceptoPago()
                            {
                                IdConceptoPago = ws.Cells[$"F{rowNumber}"].GetValue<int>(),
                            }


                        };
                        i++;
                        items.Add(item);

                    }
                    catch (Exception e)
                    {
                        //errorLoad = new { HasError = true, Message = $"[ERROR] [ROW: {rowNumber}]Error a procesar una fila en el ArchivoPago. {e.Message}".Left(255) };
                        break;
                    }

                    rowNumber++;
                }
            }

            return Json(new { success = false, message = "Ocurrió un Error en la carga" }, JsonRequestBehavior.AllowGet);
        }






        [HttpPost]
        public ActionResult AddOrEdit(ArchivoPago ArchivoPago)
        {



            if (ArchivoPago.IdArchivoPago == 0)
            {
                ArchivoPago.FechaSubida = DateTime.Today;
                bool flag = ArchivoPagoBl.RegistrarArchivoPagoBL(ArchivoPago);

                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ArchivoPago.FechaSubida = DateTime.Today;
                bool flag = this.ArchivoPagoBl.ActualizarArchivoPagoBL(ArchivoPago);
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpPost]
        public ActionResult Delete(int id)
        {


            if (ArchivoPagoBl.EliminarArchivoPago(id.ToString()))
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