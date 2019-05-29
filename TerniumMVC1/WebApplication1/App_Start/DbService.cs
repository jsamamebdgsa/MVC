using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.App_Start
{
    public class DbService
    {
        public string ConnStr
        {
            get { return ConfigurationManager.ConnectionStrings["CatalogosDb"].ConnectionString; }
        }

        public List<Producto> GetAllProductos()
        {
            List<Producto> productos = new List<Producto>();

            using(SqlConnection cnn = new SqlConnection(ConnStr))
            {
                cnn.Open();
                String sql = "SELECT Id, Codigo, Nombre, Precio, Vencimiento FROM Producto";
                SqlCommand command = new SqlCommand(sql);
                command.Connection = cnn;
                command.CommandType = System.Data.CommandType.Text;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Producto prod = new Producto();
                    prod.Codigo = reader.GetString(1);
                    prod.Nombre = reader.GetString(2);
                    prod.Precio = reader.GetFloat(3);
                    prod.Vencimiento = reader.GetDateTime(4);

                    productos.Add(prod);
                }
            }

            return productos;
        }

        public Producto AddProducto(Producto producto)
        {
            using (SqlConnection cnn = new SqlConnection(ConnStr))
            {
                cnn.Open();
                String sql = "INSERT INTO Producto(Codigo, Nombre, Precio, Vencimiento)" +
                    " OUTPUT INSERTED.Id " +
                    " VALUES(@codigo, @nombre, @precio, @vencimiento)";
                SqlCommand command = new SqlCommand(sql);
                command.Connection = cnn;
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.AddWithValue("@codigo", producto.Codigo);
                command.Parameters.AddWithValue("@nombre", producto.Nombre);
                command.Parameters.AddWithValue("@precio", producto.Precio);
                command.Parameters.AddWithValue("@vencimiento", producto.Vencimiento);
                object res = command.ExecuteScalar();
                producto.Id = Convert.ToInt32(res);
                
            }
            return producto;
        }
    }
}