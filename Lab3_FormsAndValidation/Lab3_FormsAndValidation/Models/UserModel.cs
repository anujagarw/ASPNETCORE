using Lab3_FormsAndValidation.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lab3_FormsAndValidation.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Please Enter Name")]        
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter User Name")]
        [MinLength(3, ErrorMessage = "Enter the User Name more than 3 chars")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", 
            ErrorMessage = "Required with (1 Uppercase, 1 Number, 1 Special Char and 1 Lowercase Char) and Min Length :8 Chars")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm Password does not match")]
        public string ConfirmPassword { get; set; }
        [RegularExpression("^[6789]\\d{9}$", ErrorMessage = "Please Enter Correct Mobile")]
        public string? Contact { get; set; }


        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Display(Name = "Accept Terms")]
        [ValidateCheckBox(ErrorMessage = "Please Accept Terms")]
        public bool IsTerms { get; set; }
    }
}
