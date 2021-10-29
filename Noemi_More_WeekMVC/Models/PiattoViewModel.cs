using System.ComponentModel.DataAnnotations;

namespace Noemi_More_WeekMVC.Models
{
    public class PiattoViewModel
    {
        [Required]
        public int IdPiatto { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descrizione { get; set; }
        [Required]
        public string Tipologia { get; set; }
        [Required]
        public decimal Prezzo  { get; set; }



        public int IdMenu  { get; set; }
        public MenuViewModel Menu { get; set; }

    }
}