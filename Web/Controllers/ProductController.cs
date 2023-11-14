using Business;
using Data;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            BProduct bCustomer = new BProduct();
            List<Product> products = bCustomer.GetAllProducts();

            //Convertir listado de entidades a listado de modelo
            //Entity>>>Model
            List<ProductModel> models = new List<ProductModel>();

            //Expresiones Lambda
            models = products.Select(x => new ProductModel
            {
                ProductId = x.ProductId,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Active = x.Active
            }).ToList();
            return View(models);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var bProduct = new BProduct();
            var product = bProduct.GetProductById(id);

            if (product == null)
            {
                return RedirectToAction("Index");
            }

            var productModel = new ProductModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Active = product.Active
            };

            return View(productModel);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                BProduct dataProduct = new BProduct();
                dataProduct.InsertProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var bProduct = new BProduct();
            var product = bProduct.GetProductById(id);

            if (product == null)
            {
                return RedirectToAction("Index");
            }

            var productModel = new ProductModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Active = product.Active
            };

            return View(productModel);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                BProduct bProduct = new BProduct();
                var existingCustomer = bProduct.GetProductById(id);

                if (existingCustomer == null)
                {
                    return RedirectToAction("Index");
                }

                existingCustomer.Name = productModel.Name;
                existingCustomer.Price = productModel.Price;
                existingCustomer.Stock = productModel.Stock;
                existingCustomer.Active = productModel.Active;

                bProduct.UpdateProduct(existingCustomer);

                return RedirectToAction(nameof(Index));
            }
            return View(productModel);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var bProduct = new BProduct();
            var product = bProduct.GetProductById(id);
            if (product == null)
                return RedirectToAction("Index");
            var productModel = new ProductModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Active = product.Active
            };

            return View(productModel);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int productId)
        {
            BProduct bProduct = new BProduct();
            bProduct.DeleteProduct(productId);

            return RedirectToAction(nameof(Index));
        }
    }
}
