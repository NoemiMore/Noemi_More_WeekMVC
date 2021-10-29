using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.Core.Entities
{
   public class Menu
    { public int IdMenu { get; set; }
        public string Nome { get; set; }

        //collegamento 
        public List<Piatto> Piatti { get; set; } = new List<Piatto>();
    }
}
