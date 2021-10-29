using Noemi_More_WeekMVC.Core.Entities;
using Noemi_More_WeekMVC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.EF.Repositories
{
    class RepositoryUtentiEF : IUtentiRepository
    {
        public Utente Add(Utente item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Utente item)
        {
            throw new NotImplementedException();
        }

        public List<Utente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Utente GetByEmail(string email)
        {
            using (var ctx = new MasterContext())
            {
                if (string.IsNullOrEmpty(email))
                {
                    return null;
                }
                return ctx.Utenti.FirstOrDefault(u => u.Email == email);
            }
        }
        public Utente Update(Utente item)
        {
            throw new NotImplementedException();
        }
    }
}
