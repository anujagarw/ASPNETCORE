using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApp.Interface;
using WebApp.Models;

namespace WebApp.Concrete
{
    public class ProductConcrete : IProduct
    {
        IOptions<ReadConfig> _ConnectionString;
        public ProductConcrete(IOptions<ReadConfig> connectionString)
        {
            _ConnectionString = connectionString;
        }

        public int DeleteProduct(int productId)
        {
            using (SqlConnection con = new SqlConnection(_ConnectionString.Value.DbConnection))
            {
                con.Open();
                SqlTransaction sqltrans = con.BeginTransaction();
                var param = new DynamicParameters();
                param.Add("@ProductId", productId);
                var result = con.Execute("DeleteProductById", param, sqltrans, 0, System.Data.CommandType.StoredProcedure);

                if (result > 0)
                {
                    sqltrans.Commit();
                }
                else
                {
                    sqltrans.Rollback();
                }
                return result;
            }
        }           

        public IEnumerable<ProductModel> GetAllProducts()
        {
            string sqlQuery = "SELECT * FROM Products";
            using (SqlConnection con = new SqlConnection(_ConnectionString.Value.DbConnection))
            {
                var products = con.Query<ProductModel>(sqlQuery);
                return products.ToList();
            }
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            string sqlQuery = "SELECT * FROM Categories";
            using (SqlConnection con = new SqlConnection(_ConnectionString.Value.DbConnection))
            {
                var categories = con.Query<CategoryModel>(sqlQuery);
                return categories.ToList();
            }
        }

        public ProductModel GetSingleProduct(int productId)
        {
            using (SqlConnection con = new SqlConnection(_ConnectionString.Value.DbConnection))
            {
                var param = new DynamicParameters();
                param.Add("@ProductId", productId);
                return con.Query<ProductModel>("usp_getproduct", param, null, true, 0, System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public int InsertProduct(ProductModel productmodel)
        {
            using (SqlConnection con = new SqlConnection(_ConnectionString.Value.DbConnection))
            {
                con.Open();
                SqlTransaction sqltrans = con.BeginTransaction();
                var param = new DynamicParameters();
                //param.Add("@ProductId", productmodel.ProductId);
                param.Add("@Name", productmodel.Name);
                param.Add("@UnitPrice", productmodel.UnitPrice);
                param.Add("@Description", productmodel.Description);
                param.Add("@CategoryId", productmodel.CategoryId);
                var result = con.Execute("AddNewProductDetails", param, sqltrans, 0, System.Data.CommandType.StoredProcedure);

                if (result > 0)
                {
                    sqltrans.Commit();
                }
                else
                {
                    sqltrans.Rollback();
                }
                return result;
            }
        }

        public int UpdateProduct(ProductModel productmodel)
        {
            using (SqlConnection con = new SqlConnection(_ConnectionString.Value.DbConnection))
            {
                con.Open();
                SqlTransaction sqltrans = con.BeginTransaction();
                var param = new DynamicParameters();
                param.Add("@ProductId", productmodel.ProductId);
                param.Add("@Name", productmodel.Name);
                param.Add("@UnitPrice", productmodel.UnitPrice);
                param.Add("@Description", productmodel.Description);
                param.Add("@CategoryId", productmodel.CategoryId);
                var result = con.Execute("UpdateProductDetails", param, sqltrans, 0, System.Data.CommandType.StoredProcedure);

                if (result > 0)
                {
                    sqltrans.Commit();
                }
                else
                {
                    sqltrans.Rollback();
                }
                return result;
            }
        }
    }
}