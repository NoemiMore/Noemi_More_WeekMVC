using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.Core.Entities
{
    public class Utente
    {
        public int IdUtente { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public _Ruolo Ruolo { get; set; } // cliente- ristoratore
    }
    
    public enum _Ruolo
    {
        Administrator,
        User
    }
}
