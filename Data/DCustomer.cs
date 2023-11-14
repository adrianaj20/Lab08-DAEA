using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DCustomer
    {
        public static string connectionString = "Data Source=ADRIANPC\\SQLEXPRESS;Initial Catalog=master; User ID=userAdmin; Password=tecsup";

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ListCustomers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) 
                        {
                            while (reader.Read())
                            {
                                customers.Add(new Customer
                                {
                                    CustomerId = (int)reader["customer_id"],
                                    Name = reader["name"].ToString(),
                                    Address = reader["address"].ToString(),
                                    Phone = reader["phone"].ToString(),
                                    Active = (bool)reader["active"],
                                });
                            }
                        }
                    }
                }
                connection.Close();
            }
            return customers;
        }

        //Insertar Cliente
        public void InsertCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("InsertCustomer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@name", customer.Name));
                    command.Parameters.Add(new SqlParameter("@address", customer.Address));
                    command.Parameters.Add(new SqlParameter("@phone", customer.Phone));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Actualizar Cliente
        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateCustomer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@customer_id", customer.CustomerId));
                    command.Parameters.Add(new SqlParameter("@name", customer.Name));
                    command.Parameters.Add(new SqlParameter("@address", customer.Address));
                    command.Parameters.Add(new SqlParameter("@phone", customer.Phone));
                    command.Parameters.Add(new SqlParameter("@active", customer.Active));

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Eliminar Cliente
        public void SoftDeleteCustomer(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SoftDeleteCustomer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@customer_id", customerId));

                    command.ExecuteNonQuery();
                }
                //connection.Close();
            }
        }
    }
}
