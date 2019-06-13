using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class MarcasController : ApiController
    {
        public static List<Marca> Marcas = new List<Marca>()
            {
                new Marca(){ Id=1, Nombre="Nike" },
                new Marca(){ Id=2, Nombre="Adidas" }
            };

        public List<Marca> Get()
        {
            return Marcas;
        }

        public void Post(Marca marca)
        {
            //Marcas.Add(new Marca()
            //{
            //    Id = 3,
            //    Nombre = "Nueva Marca"
            //});
            Marcas.Add(marca);
        }

        // PUT api/values/5
        //[HttpPut]
        public HttpResponseMessage Put(int id, Marca marca)
        {
            int index = Marcas.FindIndex(x => x.Id == id);
            if (index >= 0)
            {
                Marcas[index].Nombre = marca.Nombre;
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
                return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
}
