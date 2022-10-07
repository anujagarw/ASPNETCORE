using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryRepository
    {
        private SqlConnection con;

        public string ConnectionStr { get; set; }
        private void Connection()
        {
            con = new SqlConnection(ConnectionStr);
        }

        public CategoryRepository(string connectionString)
        {
            ConnectionStr = connectionString;
        }

        /// <summary>
        /// To Add Category Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddCategory(ProductModel model)
        {
            Connection();
            using (SqlCommand cmd = new SqlCommand("AddNewCategoryDetails", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Name", model.Name);
                //cmd.Parameters.AddWithValue("@Description", model.Description);
                //cmd.Parameters.AddWithValue("@UnitPrice", model.UnitPrice);
                //cmd.Parameters.AddWithValue("@CategoryId", model.CategoryId);

                con.Open();
                bool retResult = cmd.ExecuteNonQuery() >= 1;
                con.Close();

                return retResult;
            }
        }
        

        public List<CategoryModel> GetCategories()
        {
            Connection();
            List<CategoryModel> categories = new List<CategoryModel>();

            con.Open();
            var command = "Select * from Categories";
            using (SqlCommand cmd = new SqlCommand(command, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CategoryModel cate = new CategoryModel();

                    cate.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    cate.Name = reader["Name"].ToString();
                    categories.Add(cate);
                }
            }

            con.Close();
            return categories;
        }
    }
}
