using Noemi_More_WeekMVC.Core.Entities;
using Noemi_More_WeekMVC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.EF.Repositories
{
    public class RepositoryMenuEF : IMenu1Repository
    {
        public Menu Add(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Menu.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Menu.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Menu> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Menu.Include(m => m.Piatti).ToList();
            }
        }

        public Menu GetByCode(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Menu.Include(m => m.Piatti).FirstOrDefault(m => m.IdMenu == id);
            }
        }

        public Menu Update(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Menu.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
