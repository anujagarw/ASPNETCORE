using System.ComponentModel.DataAnnotations;

namespace RoutingAndNavigation_Ass11Sep22.Areas.User.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please Enter User Name")]        
        public string Username { get; set; }
        public string Password{ get; set; }
    }
}
