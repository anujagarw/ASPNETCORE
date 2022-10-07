using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ProductModel
    {
        [HiddenInput(DisplayValue=false)]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Enter Product Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Product Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter Product Price")]
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}