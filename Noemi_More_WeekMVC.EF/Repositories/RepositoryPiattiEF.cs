using Noemi_More_WeekMVC.Core.Entities;
using Noemi_More_WeekMVC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.EF.Repositories
{
    public class RepositoryPiattiEF : IPiattiRepository
    {
        public Piatto Add(Piatto item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Piatti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Piatto item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Piatti.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Piatto> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Piatti.Include(x => x.Menu).ToList();
            }
        }

        public Piatto GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Piatti.Include(p => p.Menu).FirstOrDefault(p => p.IdMenu == id);
            }
        }

        public Piatto Update(Piatto item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Piatti.Update(item);
                ctx.SaveChanges();
            }
            return item; 
        }
    }
}
