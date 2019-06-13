using EFWebApp.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFWebApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private CatalogosEntities db = new CatalogosEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //POST Index
        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            Session["Usuario"] = null;
            ViewBag.Mensaje = string.Empty;
            var user = db.Usuario.Where(x => x.Nombre == usuario.Nombre).FirstOrDefault();
            if(user != null && user.Clave == usuario.Clave)
            {
                Session["Usuario"] = user.Nombre;
                return RedirectToAction("Index", "Productos");
            }
            ViewBag.Mensaje = "Usuario no valido.";
            return View("Index");
        }
    }
}