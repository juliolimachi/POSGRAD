using BL;
using ET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Configuration;
using OfficeOpenXml;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Data;
using Newtonsoft.Json;

using System.Threading;

namespace Asp.NETMVCCRUD.Controllers
{
    public class ArchivoController : Controller
    {

        public static string DB_PATH = @"";
        protected readonly RuleSettings _fileSettings;

        public ArchivoBL ArchivoBl = new ArchivoBL();
        public AlumnoMatriculaBL AlumnoMatriculaBl = new AlumnoMatriculaBL();
        //
        // GET: /Archivo/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {

            var usuList = ArchivoBl.ObtenerArchivos();

            return Json(new { data = usuList }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            if (id == 0)
                return View(new Archivo());
            else
            {

                return View(this.ArchivoBl.ObtenerArchivoPorCodigoBL(id.ToString()));

            }
        }

        [HttpPost]
        public ActionResult Upload()
        {
          

        string directory = ConfigurationManager.AppSettings["ALumnos"];

          


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
                    var nombrearchivo = fileName;


                    Archivo archivo = new Archivo();

                    archivo.NombreArchivo = nombrearchivo;
                    archivo.Formato = formato;
                    archivo.FechaSubida = DateTime.Today;
                    archivo.Periodo = anhio + "" + mes;
                    archivo.EstadoValidacion = 1;
                    archivo.EstadoArchivo = 0;

                    if (ArchivoBl.ObtenerArchivoPorNombreBL(nombrearchivo) ==null)
                    {
                        bool flag = ArchivoBl.RegistrarArchivoBL(archivo);

                        file.SaveAs(DB_PATH); //File will be saved in application root

                        return Json(new { success = true, message = "Upload Successfully" }, JsonRequestBehavior.AllowGet);

                    }else
                    {
                        return Json(new { success = false, message = "Ya Existe un archivo con el mismo nombre" }, JsonRequestBehavior.AllowGet);
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
            List<AlumnoMatricula> items = new List<AlumnoMatricula>();


            string directory = ConfigurationManager.AppSettings["Alumnos"];

            var nombreArchivo = ArchivoBl.ObtenerArchivoPorCodigoBL(id);
            var path = Path.Combine(directory, nombreArchivo.NombreArchivo);

            using (var instream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            using (var pck = new ExcelPackage(instream))
            {
                var ws = pck.Workbook.Worksheets["F001"];

                if (ws == null)
                {
                    //throw new BusinessExceptions("No se encontro una Hoja Excel con el nombre: [F.211].");
                }

                int rowNumber = 7;
                int i = 0;
                while (!string.IsNullOrEmpty(ws.Cells[$"A{rowNumber}"].GetValue<string>()))
                {
                    var costoxmes = ws.Cells[$"B{4}"].GetValue<int>();
                    var programa = ws.Cells[$"B{2}"].GetValue<int>();
                    var semestre = ws.Cells[$"B{3}"].GetValue<int>();

                    try
                    {
                        var item = new AlumnoMatricula()
                        {
                            CodigoAlumno = ws.Cells[$"B{rowNumber}"].GetValue<int>(),
                            NombreAlumno = ws.Cells[$"C{rowNumber}"].GetValue<string>(),
                            CreditoAlumno = ws.Cells[$"D{rowNumber}"].GetValue<int>(),
                            Especialidad = ws.Cells[$"E{rowNumber}"].GetValue<int>(),
                            Sexo = ws.Cells[$"F{rowNumber}"].GetValue<string>(),
                            Ciclo = ws.Cells[$"G{rowNumber}"].GetValue<int>(),
                            AnhoIngreso = ws.Cells[$"H{rowNumber}"].GetValue<int>(),
                            UsuarioRegistro = ws.Cells[$"I{rowNumber}"].GetValue<string>(),
                            FechaMatricula = ws.Cells[$"J{rowNumber}"].GetValue<DateTime>(),
                            CodigoSemestre= semestre,
                            MontoCiclo = ws.Cells[$"D{rowNumber}"].GetValue<int>() * costoxmes,
                            IdPrograma=programa,
                            PrecioCredito= costoxmes,
                     
                        };
                        i++;
                        items.Add(item);
                
                    }
                    catch (Exception e)
                    {
                        //errorLoad = new { HasError = true, Message = $"[ERROR] [ROW: {rowNumber}]Error a procesar una fila en el archivo. {e.Message}".Left(255) };
                        break;
                    }

                    rowNumber++;
                }
            }

            bool flag = AlumnoMatriculaBl.InsertarAlumnoMatricula(items);


            if (flag)
            {
                return Json(new { success = false, message = "Update Successfully" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, message = "Ocurrió un Error en la carga" }, JsonRequestBehavior.AllowGet);
            }


       
        }






        [HttpPost]
        public ActionResult AddOrEdit(Archivo archivo)
        {



            if (archivo.IdArchivo == 0)
            {
                archivo.FechaSubida = DateTime.Today;
                bool flag = ArchivoBl.RegistrarArchivoBL(archivo);
            
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                archivo.FechaSubida = DateTime.Today;
                bool flag = this.ArchivoBl.ActualizarArchivoBL(archivo);
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpPost]
        public ActionResult Delete(int id)
        {


            if (ArchivoBl.EliminarArchivo(id.ToString()))
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