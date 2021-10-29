using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Noemi_More_WeekMVC.Core.Entities;
using Noemi_More_WeekMVC.Core.Interfaces;
using Noemi_More_WeekMVC.Helper;
using Noemi_More_WeekMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly IBusinessLayer BL;



        public MenuController(IBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var menu = BL.GetAllMenu();

            List<MenuViewModel> menuViewModel = new List<MenuViewModel>();

            foreach (var item in menu)
            {
                menuViewModel.Add(item.ToMenuViewModel());
            }

            return View(menuViewModel);
        }


        [HttpGet("Menu/Details/{id}")]
       
        public IActionResult Details(int id )
        {
            var menu = BL.GetAllMenu().FirstOrDefault(m => m.IdMenu == id);

            var menuViewModel = menu.ToMenuViewModel();

            return View(menuViewModel);

        }




        [Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Create(CorsoViewModel corsoViewModel)
        {
            if (ModelState.IsValid)
            {
                var corso = corsoViewModel.ToCorso();
                BL.InserisciNuovoCorso(corso);
                return RedirectToAction(nameof(Index));
            }
            return View(corsoViewModel);
        }

        [Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var corso = BL.GetAllCorsi().FirstOrDefault(c => c.CorsoCodice == id);
            var corsoViewModel = corso.ToCorsoViewModel();
            return View(corsoViewModel);
        }

        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Edit(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                var corso = menuViewModel.ToMenu();
                BL.UpdateMenu(menu.IdMenu, menu.Nome);
                return RedirectToAction(nameof(Index));
            }
            return View(menuViewModel);
        }

        [Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var menu = BL.GetAllMenu().FirstOrDefault(m => m.IdMenu == id);
            var menuViewModel = menu.ToMenuViewModel();
            return View(menuViewModel);
        }

        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Delete(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {

                var corso = menuViewModel.ToMenu();
                BL.DeleteMenu(menu.IdMenu);
                return RedirectToAction(nameof(Index));

            }
            return View(menuViewModel);
        }






    }
}
