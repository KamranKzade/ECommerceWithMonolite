using System.ComponentModel.DataAnnotations;

namespace ECommorce.WebUI.Models
{
    public class LogInViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
