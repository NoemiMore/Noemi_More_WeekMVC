using Noemi_More_WeekMVC.Core.Entities;
using Noemi_More_WeekMVC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IMenu1Repository menuRepo;
        private readonly IPiattiRepository piattiRepo;
        private readonly IUtentiRepository utentiRepo;

        private static string errorString = "\nErrore nella manipolazione dati.";



        public MainBusinessLayer(IMenu1Repository menu, IPiattiRepository piatti, IUtentiRepository utenti)
        {
            menuRepo = menu;
            piattiRepo = piatti;
            
            utentiRepo = utenti;
        }

        public List<Menu> GetAllMenu()
        {
            return menuRepo.GetAll();
        }

        public string AddNewMenu(Menu newMenu)
        {
            Menu menuEsistente = menuRepo.GetByCode(newMenu.IdMenu);
            if (menuEsistente != null)
            {
                return "Errore: Id menu già presente";
            }
            menuRepo.Add(newMenu);
            return "Menu aggiunto correttamente";
        }

        public string UpdateMenu(int idMenuDaModificare, string nuovoNome)
        {
            Menu menuEsistente = menuRepo.GetByCode(idMenuDaModificare);
            if (menuEsistente == null)
            {
                return "Errore: Id menu errato.";
            }
            menuEsistente.Nome = nuovoNome;
           
            menuRepo.Update(menuEsistente);
            return "Il menu è stato modificato con successo";
        }

        public string DeleteMenu(int idMenuDaEliminare)
        {
            Menu menuEsistente = menuRepo.GetByCode(idMenuDaEliminare);
            if (menuEsistente == null)
            {
                return "Errore: Id errato.";
            }
            menuRepo.Delete(menuEsistente);
            return "Menu eliminato correttamente";
        }






        public List<Piatto> GetAllPiatti()
        {
            return piattiRepo.GetAll();
        }

        public string AddNewPiatto(Piatto newPiatto)
        {
            Menu menuEsistente = menuRepo.GetByCode(newPiatto.IdMenu);
            if (menuEsistente == null)
            {
                return "Id menu errato";
            }
            piattiRepo.Add(newPiatto);
            return "piatto inserito correttamente";
        }

        public string UpdatePiatto(int idPiattoDaModificare, string nuovoNome, string nuovaDescrizione, decimal nuovoPrezzo)
        {
            var piatto = piattiRepo.GetById(idPiattoDaModificare);
            if (piatto == null)
            {
                return "Id piatto errato o inesistente";
            }
            piatto.Nome = nuovoNome;
            piatto.Descrizione = nuovaDescrizione;
            piatto.Prezzo = nuovoPrezzo;
            piattiRepo.Update(piatto);
            return "Email Studente aggiornata correttamente";
        }

        public string DeletePiatto(int idPiattoDaEliminare)
        {
            var piattoEsistente = piattiRepo.GetById(idPiattoDaEliminare);
            if (piattoEsistente == null)
            {
                return "Id non valido.Impossibile eliminare.";
            }
            piattiRepo.Delete(piattoEsistente);
            return "Piatto eliminato con successo";
        }

        public IList<Piatto> GetPiattiByNomeMenu(string nomeMenu)
        {
            if (string.IsNullOrEmpty(nomeMenu) == true)
            {
                return null;
            }
            var piatti = new List<Piatto>();
            piatti = piattiRepo.GetAll().Where(p => p.Nome == nomeMenu).ToList();
            return piatti;
        }

        

        public Utente GetAccount(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return null;
            }
           return utentiRepo.GetByEmail(email);
        }

        List<Piatto> IBusinessLayer.GetPiattiByNomeMenu(string nomeMenu)
        {
            throw new NotImplementedException();
        }
    }
}
