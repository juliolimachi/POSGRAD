using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ET.Model;
using ET;
using BL;

namespace Asp.NETMVCCRUD.Controllers
{
    public class AccountController : Controller
    {
        UsuarioBL usuariobl = new UsuarioBL();

        // GET: Account
        public ActionResult Index(string returnUrl = null)
        {

            returnUrl = returnUrl ?? "/";

            var viewModel = new LoginViewModel { ReturnUrl = returnUrl };

            return View(viewModel);
            
        }



        [HttpPost]
        [AllowAnonymous]
        [Route("index")]
        public ActionResult Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Debe de ingresar el Usuario y Password.";
                return View(model);
            }
            try
            {

                Usuario usuario = usuariobl.ObtenerUsuarioCredencialesBL(model.UserName, model.Password);
                if (usuario == null)
                {
                    throw new Exception("El Usuario y/o Password es incorrecto.");
                }
             
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = e.Message;
                return View(model);
            }

            return Redirect(returnUrl);
        }

    }
}