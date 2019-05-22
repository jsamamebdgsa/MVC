using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public DateTime Vencimiento { get; set; }

        public String StrVencimiento
        {
            get { return Vencimiento.ToString("yyyy-MM-dd"); }
            set { Vencimiento = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture); }
        }
    }
}