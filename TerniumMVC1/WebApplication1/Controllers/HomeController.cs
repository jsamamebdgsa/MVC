using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Hola";
        }

        // GET: Home
        [HttpGet]
        public string Saludo()
        {
            return "Negrita:<b>Happy coding</b>";
        }

        // POST: Home
        [HttpPost]
        public string SaludoSensible()
        {
            return "Negrita:<b>Bad coding</b>";

        }
        //<form action="" method="POST">
            
            
        //    </form>

        // GET: Home
        public string Message()
        {
            return "<script>alert('Hola mundo')</script>";
        }

        public Producto Producto()
        {
            Producto p = new Producto();
            p.Codigo = "123466";
            p.Nombre = "Laptop Acer";
            p.Precio = 2569.25f;
            p.Vencimiento = DateTime.Now.AddYears(2);
            return p;
        }

        public JsonResult Producto2()
        {
            Producto p = new Producto();
            p.Codigo = "123466";
            p.Nombre = "Laptop Acer";
            p.Precio = 2569.25f;
            p.Vencimiento = DateTime.Now.AddYears(2);
            return Json(p);
        }

        [HttpPost]
        public JsonResult Producto3()
        {
            Producto p = new Producto();
            p.Codigo = "123466";
            p.Nombre = "Laptop Acer";
            p.Precio = 2569.25f;
            p.Vencimiento = DateTime.Now.AddYears(2);
            return Json(p);
        }
    }
}