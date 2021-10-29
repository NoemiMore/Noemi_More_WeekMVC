using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    [Authorize(Policy = "Adm")]
    public class PiattiController : Controller
    {

        private readonly IBusinessLayer BL; 
        public PiattiController(IBusinessLayer bl)
        {
            BL = bl; 
        }

        public IActionResult Index()
        {
            var piatti = BL.GetAllPiatti();
            List<PiattoViewModel> piattiViewModel = new List<PiattoViewModel>();
            foreach (var item in piatti)
            {
                piattiViewModel.Add(item?.ToPiattoViewModel());
            }
            return View(piattiViewModel);
        }







        public IActionResult Details(int id)
        {
            var studente = BL.GetAllStudenti().FirstOrDefault(s => s.ID == id);
            var studenteViewModel = studente.ToStudenteViewModel();
            return View(studenteViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadViewBag();
            return View();
        }
        [HttpPost]
        public IActionResult Create(PiattoViewModel piattoViewModel)
        {
            if (ModelState.IsValid)
            {
                var piatto = piattoViewModel.ToPiatto();
                BL.AddNewPiatto(piatto);
                return RedirectToAction(nameof(Index));
            }
            LoadViewBag();
            return View(piattoViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var piatto = BL.GetAllPiatti().FirstOrDefault(p => p.IdPiatto == id);
            var piattoViewModel = piatto.ToPiattoViewModel();
            LoadViewBag();
            return View(piattoViewModel);
        }

        [HttpPost]
        public IActionResult Edit(PiattoViewModel piattoViewModel)
        {
            if (ModelState.IsValid)
            {
                var studente = piattoViewModel.ToPiatto();
                BL.UpdatePiatto(piatto.idPiattoDaModificare, piatto.nuovoNome, piatto.nuovaDescrizione, piatto.nuovoPrezzo);
                return RedirectToAction(nameof(Index));
            }
            LoadViewBag();
            return View(piattoViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var piatto = BL.GetAllPiatti().FirstOrDefault(p => p.IdPiatto == id);
            var piattoViewModel = piatto.ToPiattoViewModel();
            return View(piattoViewModel);
        }

        [HttpPost]
        public IActionResult Delete(PiattoViewModel piattoViewModel)
        {
            var piatto = piattoViewModel.ToPiatto();
            BL.DeletePiatto(piatto.IdPiatto);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult DeleteJS(int id)
        {
            var messaggio = BL.DeletePiatto(id);
            if (messaggio == "Piatto eliminato correttamente")
            {
                return Json(true);
            }

            return Json(false);
        }
        private void LoadViewBag()
        {
            ViewBag.Tipologia = new SelectList(new[]{
                new { Value="P", Text="Primo"},
                new { Value="S", Text="Secondo"} ,
            new { Value = "C", Text = "Contorno" },
             new { Value = "D", Text = "Dolce" }
            }.OrderBy(x => x.Text), "Value", "Text");


        }





    }
}
