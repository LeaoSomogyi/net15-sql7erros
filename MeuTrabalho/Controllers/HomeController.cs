using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeuTrabalho.Models;
using System.Data.SqlClient;
using MeuTrabalho.Context;

namespace MeuTrabalho.Controllers
{
    public class HomeController : Controller, IDisposable
    {
        private IDatabaseContext _databaseContext;

        public HomeController(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
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
                _databaseContext.ExecuteCommand("INSERT tbLog VALUES ('about')");
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
                _databaseContext.ExecuteCommand("INSERT tbLog VALUES ('contact')");
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
