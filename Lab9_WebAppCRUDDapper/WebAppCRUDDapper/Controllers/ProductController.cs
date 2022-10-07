using Microsoft.AspNetCore.Mvc;
using WebApp.Interface;
using WebApp.Models;
using WebApp.Models.Paging;
/*
 # Lab6: Listing, Paging and Sorting
 */

namespace WebAppCRUDDapper.Controllers
{
    public class ProductController : Controller
    {
        /*
         Index - for display list of product
            Create - for creating New product
            Edit - for updating product information
            Delete - for Deleting product
            Details – For showing details of single product
         */
        IProduct _product;
        public ProductController(IProduct product)
        {
            _product = product;
        }

        private List<ProductModel> SortProductData(List<ProductModel> products, string sortField, string currentSortField, string currentSortOrder)
        {
            if (string.IsNullOrEmpty(sortField))
            {
                ViewBag.SortField = "Name";
                ViewBag.SortOrder = "Asc";
            }
            else
            {
                if (currentSortField == sortField)
                {
                    ViewBag.SortOrder = currentSortOrder == "Asc" ? "Desc" : "Asc";
                }
                else
                {
                    ViewBag.SortOrder = "Asc";
                }
                ViewBag.SortField = sortField;
            }

            var propertyInfo = typeof(ProductModel).GetProperty(ViewBag.SortField);
            if (ViewBag.SortOrder == "Asc")
            {
                products = products.OrderBy(s => propertyInfo.GetValue(s, null)).ToList();
            }
            else
            {
                products = products.OrderByDescending(s => propertyInfo.GetValue(s, null)).ToList();
            }
            return products;
        }

        //public IActionResult Index(string sortField, string currentSortField, string currentSortOrder, string SearchString)
        //{
        //    var products = _product.GetAllProducts();
        //    //Searching
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        products = products.Where(s => s.Name.Contains(SearchString)).ToList();
        //    }
        //    return View(this.SortProductData(products.ToList(), sortField, currentSortField, currentSortOrder));
        //}

        public IActionResult Index(string sortField, string currentSortField, string currentSortOrder, string currentFilter, 
            string SearchString, int? pageNo)
        {
            var products = _product.GetAllProducts();
            if (SearchString != null)
            {
                pageNo = 1;
            }
            else
            {
                SearchString = currentFilter;
            }

            ViewData["CurrentSort"] = sortField;
            ViewBag.CurrentFilter = SearchString;

            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.Name.Contains(SearchString)).ToList();
            }
            products = this.SortProductData(products.ToList(), sortField, currentSortField, currentSortOrder);
            int pageSize = 4;
            return View(PagingList<ProductModel>.CreateAsync(products.AsQueryable<ProductModel>(), pageNo ?? 1, pageSize));
        }


        //public IActionResult Index()
        //{
        //    var products = _product.GetAllProducts();
        //    return View(products);
        //}

        /// <summary>
        /// Adding new records
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewBag.Categories = _product.GetCategories();
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
                _product.InsertProduct(model);
                return RedirectToAction("Index"); // product Home page
            }
            ViewBag.Categories = _product.GetCategories();
            return View();
        }

        /// <summary>
        /// Edit old records - when user click to Edit button - Async style
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _product.GetCategories();

            ProductModel model = _product.GetSingleProduct(id);

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
                _product.UpdateProduct(model);
                return RedirectToAction("Index"); // product Home page
            }
            ViewBag.Categories = _product.GetCategories();
            return View();
        }

        /// <summary>
        /// Delete selected records - when user click to Delete button
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            _product.DeleteProduct(id);
            return RedirectToAction("Index"); // Go to the Listing Page
        }
    }
}
