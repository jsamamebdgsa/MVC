using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CatalogoController : Controller
    {
        // GET: Catalogo
        public ActionResult Index()
        {
            ViewBag.Subtitulo = "Listado";
            return View();
        }

        // GET: Catalogo
        public ActionResult Listado()
        {
            ViewBag.Subtitulo = "Listado 2";
            return View("Index");
        }

        // GET: Catalogo
        public ActionResult Loguear(int id)
        {
            if (id == 1)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Listado");
        }

        // GET: Catalogo
        public ActionResult Lista()
        {
            ViewBag.Subtitulo = "Lista";
            List<Producto> modelo = MvcApplication.Database.Productos;
            return View("Index", modelo);
        }

        // GET: Catalogo
        public ActionResult Crear()
        {
            MvcApplication.Database.Productos.Add(new Producto()
            {
                Codigo = 10001.ToString("0000"),
                Nombre = "Producto Creado #" + 10001,
                Precio = 900.50f,
                Vencimiento = DateTime.Now.AddYears(20)
            });
            return RedirectToAction("Lista");
        }

        public ActionResult Creacion()
        {
            ViewBag.Subtitulo = "Nuevo";
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Producto producto)
        {
            MvcApplication.Database.Productos.Add(producto);
            return RedirectToAction("Lista");
        }

        public ActionResult Editar(string id)
        {
            ViewBag.Subtitulo = "Edicion";
            var modelo = MvcApplication.Database.Productos.Find(x => x.Codigo == id);
            return View("Editar", modelo);
        }

        [HttpPost]
        public ActionResult Actualizar(Producto producto)
        {
            var indice = MvcApplication.Database.Productos.FindIndex(x => x.Codigo == producto.Codigo);

            MvcApplication.Database.Productos[indice].Nombre = producto.Nombre;
            MvcApplication.Database.Productos[indice].Precio = producto.Precio;
            MvcApplication.Database.Productos[indice].StrVencimiento = producto.StrVencimiento;
            //MvcApplication.Database.Productos[indice].Vencimiento = producto.Vencimiento;

            return RedirectToAction("Lista");
        }
    }
}