using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.App_Start
{
    public class DataStore
    {
        public List<Producto> Productos = new List<Producto>();

        public DataStore()
        {
            for (int i = 1; i <= 20; i++)
            {
                Productos.Add(new Producto()
                {
                    Codigo = i.ToString("0000"),
                    Nombre = "Producto #" + i,
                    Precio = 100.50f,
                    Vencimiento = DateTime.Now.AddYears(25)
                });
            }
        }
    }
}