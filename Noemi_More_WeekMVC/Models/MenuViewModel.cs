using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.Models
{
    public class MenuViewModel
    {
        [Required(ErrorMessage = "Campo obbligatorio")]
        [DisplayName("Codice Menu")]
        public int IdMenu { get; set; }

        [Required]
        [DisplayName("Nome Menu")]
        public string Nome { get; set; }


        public List<PiattoViewModel> Piatti { get; set; } = new List<PiattoViewModel>();
    }
}
