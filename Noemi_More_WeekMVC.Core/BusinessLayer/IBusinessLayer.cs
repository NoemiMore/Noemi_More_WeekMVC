using Noemi_More_WeekMVC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.Core.Interfaces
{
    public interface IBusinessLayer
    {
        //crud menu
        public List<Menu> GetAllMenu();
        public string AddNewMenu(Menu newMenu );
        public string UpdateMenu(int idMenuDaModificare, string nuovoNome );
        public string DeleteMenu(int idMenuDaEliminare);
      //  Menu GetMenuByCode(int id);
        //List<Piatto> GetAllPiatti();


        //crud piatto


        public List<Piatto> GetAllPiatti();
       public string AddNewPiatto(Piatto newPiatto);
        public string UpdatePiatto(int idPiattoDaModificare, string nuovoNome, string nuovaDescrizione, decimal nuovoPrezzo);
        public string DeletePiatto (int idPiattoDaEliminare);
        public List<Piatto> GetPiattiByNomeMenu(string nomeMenu );
        //public IList <Piatto> GetPiattiByNomeMenu(string nomeMenu);



        //utente
        Utente GetAccount(string email);
    }
}
