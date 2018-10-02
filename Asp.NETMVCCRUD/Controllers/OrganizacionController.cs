
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
    public class OrganizacionController : Controller
    {
        //
        // GET: /Organizacion/
        private OrganizacionBL organizacionBL = new OrganizacionBL();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            
                var usuList = organizacionBL.ObtenerOrganizacions();


                return Json(new { data = usuList }, JsonRequestBehavior.AllowGet);
           
        }




        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Organizacion());
            else
            {
                    return View(organizacionBL.ObtenerOrganizacionPorCodigoBL(id.ToString()));
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Organizacion org)
        {
            
                if (org.IdOrganizacion == 0)
                {
                    org.FechaCreacion = DateTime.Today;
                    var flag = organizacionBL.GuardarOrganizacion(org);
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    org.FechaCreacion = DateTime.Today;
                    var flag = organizacionBL.GuardarOrganizacion(org);
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
          


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {


            if (this.organizacionBL.EliminarUsuario(id.ToString()))
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