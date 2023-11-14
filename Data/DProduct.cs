using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DProduct
    {
        //Cadena de conexion
        public static string connectionString = "Data Source=ADRIANPC\\SQLEXPRESS;Initial Catalog=master; User ID=userAdmin; Password=tecsup";


        //Listar Productos
        public List<Product> GetAllP()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ListProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                products.Add(new Product
                                {
                                    ProductId = (int)reader["product_id"],
                                    Name = reader["name"].ToString(),
                                    Price = (decimal)reader["price"],
                                    Stock = (int)reader["stock"],
                                    Active = (bool)reader["active"],
                                });
                            }
                        }
                    }
                }
                connection.Close();
            }
            return products;
        }

        //Insertar Producto
        public void InsertProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("InsertProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@name", product.Name));
                    command.Parameters.Add(new SqlParameter("@price", product.Price));
                    command.Parameters.Add(new SqlParameter("@stock", product.Stock));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Actualizar Producto
        public void UpdateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@product_id", product.ProductId));
                    command.Parameters.Add(new SqlParameter("@name", product.Name));
                    command.Parameters.Add(new SqlParameter("@price", product.Price));
                    command.Parameters.Add(new SqlParameter("@stock", product.Stock));
                    command.Parameters.Add(new SqlParameter("@active", product.Active));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Eliminar producto
        public void SoftDeleteProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SoftDeleteProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@product_id", productId));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
