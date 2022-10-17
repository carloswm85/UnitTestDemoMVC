using Microsoft.AspNetCore.Mvc;
using UnitTestDemo.Web.Models;

namespace UnitTestDemo.Web.Controllers
{
    public class ProductController : Controller
    {
        public IList<Product> products = new List<Product>();
        Product product = new Product(1, "VCR");

        public IActionResult Index()
        {
            CreateProducts();
            return View(products);
        }

        private void CreateProducts()
        {
            products.Add(product);
            Product product2 = new Product(2, "Television");
            products.Add(product2);
            Product product3 = new Product(3, "Gaming console");
            products.Add(product3);
        }

        public ActionResult Details(int id)
        {
            if (id < 1)
            {
                return RedirectToAction("Index");
            }
            CreateProducts();
            // Get object with Id equals to id
            var product = products.Where(x => x.Id == id);
            // Then gets its name and return that string
            var name = product.FirstOrDefault()?.Name;
            return View("Details", name);
        }
    }
}
