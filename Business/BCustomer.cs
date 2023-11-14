using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BCustomer
    {
        public List<Customer> GetAllCustomers()
        {
            DCustomer dataCustomer = new DCustomer();
            List<Customer> allCustomers = dataCustomer.GetAll();
            return allCustomers;
        }

        public List<Customer> SearchCustomersByName(string name)
        {
            List<Customer> allCustomers = GetAllCustomers();

            List<Customer> filteredCustomers = allCustomers
                .Where(c => c.Name.Contains(name))
                .ToList();

            return filteredCustomers;
        }

        public Customer GetCustomerById(int customerId)
        {
            DCustomer dataCustomer = new DCustomer();
            Customer customer = dataCustomer.GetAll().FirstOrDefault(c => c.CustomerId == customerId);
            return customer;
        }

        public void InsertCustomer(Customer customer)
        {
            DCustomer dataCustomer = new DCustomer();
            dataCustomer.InsertCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            DCustomer dataCustomer = new DCustomer();
            dataCustomer.UpdateCustomer(customer);
        }
        public void DeleteCustomer(int customerId)
        {
            DCustomer dataCustomer = new DCustomer();
            dataCustomer.SoftDeleteCustomer(customerId);
        }




    }
}
