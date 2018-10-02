

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;

using ET;
using BL;


namespace Asp.NETMVCCRUD.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Sistemas
        private UsuarioBL usuarioBL = new UsuarioBL();
  

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
                var usuList = this.usuarioBL.ObtenerUsuarios();
                return Json(new { data = usuList }, JsonRequestBehavior.AllowGet);
        


      

        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Usuario());
            else
            {

                var usuList = this.usuarioBL.ObtenerUsuarioPorCodigoBL(id.ToString());
                    return View(usuList);
                
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Usuario usu)
        {

            usu.FechaCreacion = DateTime.Today;
           
                if (usu.IdUsuario == 0)
                {
                   
                    bool flag = usuarioBL.GuardarUsuario(usu);

                 
                    return Json(new { success = true, message = "Guardado Correctamente" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    bool flag = usuarioBL.GuardarUsuario(usu);
                    return Json(new { success = true, message = "Actualizado Correctamente" }, JsonRequestBehavior.AllowGet);
                }
        

        }

     


        [HttpPost]
        public ActionResult Delete(int id)
        {
       


            if(this.usuarioBL.EliminarUsuario(id.ToString())){


                return Json(new { success = true, message = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                return Json(new { success = false, message = "Error Successfully" }, JsonRequestBehavior.AllowGet);
            }



        }
	}
}