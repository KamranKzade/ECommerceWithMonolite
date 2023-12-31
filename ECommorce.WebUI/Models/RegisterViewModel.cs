﻿using System.ComponentModel.DataAnnotations;

namespace ECommorce.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
