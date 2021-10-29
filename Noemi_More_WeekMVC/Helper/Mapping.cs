using Noemi_More_WeekMVC.Core.Entities;
using Noemi_More_WeekMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.Helper
{
    public static class Mapping
    {
        public static MenuViewModel ToMenuViewModel(this Menu menu)
        {
            List<PiattoViewModel> piattiiViewModel = new List<PiattoViewModel>();
            foreach (var item in menu.Piatti)
            {
                piattiViewModel.Add(item?.ToPiattoViewModel());
            }

            return new MenuViewModel
            {
                IdMenu = menu.IdMenu,
                Nome = menu.Nome,

                Piatti = piattiViewModel
            };


        }



        public static Menu ToMenu(this MenuViewModel menuViewModel)
        {
            List<Piatto> studenti = new List<Piatto>();
            foreach (var item in menuViewModel.Piatti)
            {
                piatti.Add(item?.ToPiatto());
            }

            return new Menu
            {
                IdMenu = menuViewModel.IdMenu,
                Nome = menuViewModel.Nome,

                Piatti = piatti

            };
        }

        public static PiattoViewModel ToPiattoViewModel(this Piatto piatto)
        {
            return new PiattoViewModel
            {
                IdPiatto = piatto.IdPiatto,
                Nome = piatto.Nome,
                Descrizione = piatto.Descrizione,
                //Tipologia = piatto.Tipologia,

                Prezzo = piatto.Prezzo,
                IdMenu = piatto.IdMenu
            };
        }

        public static Piatto ToPiatto(this PiattoViewModel piattoViewModel)
        {
            return new Piatto
            {
                IdPiatto = piattoViewModel.IdPiatto,
                Nome = piattoViewModel.Nome,
                Descrizione = piattoViewModel.Descrizione,
                Prezzo = piattoViewModel.Prezzo,
                IdMenu = piattoViewModel.IdMenu
            };
        }


    }

    }
