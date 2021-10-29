using Noemi_More_WeekMVC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.Core.Interfaces
{
    public interface IUtentiRepository : IRepository<Utente>
    {
        Utente GetByEmail(string email);
    }
}
