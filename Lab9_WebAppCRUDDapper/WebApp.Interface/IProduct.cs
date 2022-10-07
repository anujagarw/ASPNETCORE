using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Interface
{
    public interface IProduct
    {
        ProductModel GetSingleProduct(int productId);
        IEnumerable<ProductModel> GetAllProducts();
        IEnumerable<CategoryModel> GetCategories();
        int InsertProduct(ProductModel productModel);
        int UpdateProduct(ProductModel productModel);
        int DeleteProduct(int productId);
    }
}
