using MeuTrabalho.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MeuTrabalho.Controllers
{
    public class HomeController : Controller, IDisposable
    {
        private readonly IHomeRepository _homeRepository;

        public HomeController(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public IActionResult Index()
        {
            return RedirectToActionPermanent("Index", "Account");
        }

        public IActionResult Dashboard(string name)
        {
            ViewBag.Name = name ?? throw new ArgumentNullException(name);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            try
            {
                _homeRepository.InsertLog("about");
            }
            catch
            {
                ViewData["Message"] = "ERROR ABOUT";
            }

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            try
            {
                _homeRepository.InsertLog("contact");
            }
            catch
            {
                return RedirectToAction("Error");
            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
