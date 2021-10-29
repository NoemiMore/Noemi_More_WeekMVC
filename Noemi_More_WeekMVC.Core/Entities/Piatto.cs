using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.Core.Entities
{
    public class Piatto
    {
        public int IdPiatto { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public _Tipologia Tipologia { get; set; }
    public decimal Prezzo { get; set; }



        public int IdMenu { get; set; }
        public virtual Menu Menu  { get; set; }

    }

    public enum _Tipologia
        {
            Primo,
            Secondo,
            Contorno,
            Dolce
        }
    }

   

