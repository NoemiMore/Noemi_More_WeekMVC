using Noemi_More_WeekMVC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.Core.Interfaces
{
    public interface IPiattiRepository : IRepository<Piatto>
    {
        public Piatto GetById(int id);
        //List<Piatto> GetByCodiceMenu(int idMenu);
        
        //List<Piatto> GetByNomeMenu(string nomeMenu);
    }
    
}
