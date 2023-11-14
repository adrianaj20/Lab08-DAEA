using Business;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        public ActionResult Index()
        {

            BCustomer bCustomer = new BCustomer();
            List<Customer> customers = bCustomer.GetAllCustomers();

            //Convertir listado de entidades a listado de modelo
            //Entity>>>Model
            List<CustomerModel> models = new List<CustomerModel>();

            //Expresiones Lambda
            models = customers.Select(x => new CustomerModel
            {
                CustomerId = x.CustomerId,
                Name = x.Name,
                Address = x.Address,
                Phone = x.Phone,
                Active = x.Active
            }).ToList();

            return View(models);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var bCustomer = new BCustomer();
            var customer = bCustomer.GetCustomerById(id);

            if (customer == null)
            {
                return RedirectToAction("Index");
            }

            var customerModel = new CustomerModel
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.Phone,
                Active = customer.Active
            };

            return View(customerModel);
        }


        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                BCustomer dataCustomer = new BCustomer();
                dataCustomer.InsertCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }


        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var bCustomer = new BCustomer();
            var customer = bCustomer.GetCustomerById(id);

            if (customer == null)
            {
                return RedirectToAction("Index");
            }

            var customerModel = new CustomerModel
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.Phone,
                Active = customer.Active
            };

            return View(customerModel);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                BCustomer bCustomer = new BCustomer();
                var existingCustomer = bCustomer.GetCustomerById(id);

                if (existingCustomer == null)
                {
                    return RedirectToAction("Index");
                }

                existingCustomer.Name = customerModel.Name;
                existingCustomer.Address = customerModel.Address;
                existingCustomer.Phone = customerModel.Phone;
                existingCustomer.Active = customerModel.Active;

                bCustomer.UpdateCustomer(existingCustomer);

                return RedirectToAction(nameof(Index));
            }
            return View(customerModel);
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var bCustomer = new BCustomer();
            var customer = bCustomer.GetCustomerById(id);
            if (customer == null)
                return RedirectToAction("Index");
            var customerModel = new CustomerModel
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.Phone,
                Active = customer.Active
            };

            return View(customerModel);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int customerId)
        {
            BCustomer bCustomer = new BCustomer();
            bCustomer.DeleteCustomer(customerId);

            return RedirectToAction(nameof(Index));
        }
    }
}
