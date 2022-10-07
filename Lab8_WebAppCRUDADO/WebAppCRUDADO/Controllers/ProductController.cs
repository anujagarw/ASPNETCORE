using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAppCRUDADO.Controllers
{
    public class ProductController : Controller
    {
        IConfiguration _configuration;
        ProductRepository _productRepository;
        CategoryRepository _categoryRepository;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
            _productRepository = new ProductRepository(_configuration.GetConnectionString("DbConnection"));
            _categoryRepository = new CategoryRepository(_configuration.GetConnectionString("DbConnection"));
        }
        /// <summary>
        /// Getting the List and Show in UI
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //ProductRepository productRepository = new ProductRepository(_configuration.GetConnectionString("DbConnection"));
            var products = _productRepository.GetProducts(); 
            return View(products);
        }

        /// <summary>
        /// Adding new records
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            //CategoryRepository categoryRepos = new CategoryRepository(_configuration.GetConnectionString("DbConnection"));
            ViewBag.Categories = _categoryRepository.GetCategories();
            return View();
        }

        /// <summary>
        /// Adding new records after create buttons and saving changes to DB
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(ProductModel model)
        {
            ModelState.Remove("ProductId"); //It is optional field for create, so removed it
            if (ModelState.IsValid)
            {
                _productRepository.AddProduct(model);
                return RedirectToAction("Index"); // product Home page
            }
            ViewBag.Categories = _categoryRepository.GetCategories();
            return View();
        }

        /// <summary>
        /// Edit old records - when user click to Edit button - Async style
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _categoryRepository.GetCategories();

            ProductModel model = _productRepository.GetProductById(id);

            return View("Create", model); //Call Create View and pass model 
        }

        /// <summary>
        /// Adding new records after create buttons and saving changes to DB
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                _productRepository.UpdateProduct(model);
                return RedirectToAction("Index"); // product Home page
            }
            ViewBag.Categories = _categoryRepository.GetCategories();
            return View();
        }

        /// <summary>
        /// Delete selected records - when user click to Delete button
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            return RedirectToAction("Index"); // Go to the Listing Page
        }
    }
}
