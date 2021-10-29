using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.Models
{
    public class UtenteLoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }


        public string ReturnUrl { get; set; }
    }
}
