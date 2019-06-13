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
    public class AccountController : Controller
    {
        private IDatabaseContext _databaseContext;

        public AccountController(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginViewModel model)
        {
            try
            {
                IEnumerable<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("@user", model.Email),
                    new KeyValuePair<string, string>("@pwd", model.Password)
                };

                var result = _databaseContext.ExecuteProcedure("spLogin", parameters);

                return Redirect($"/Home/Dashboard?name={result.ToString()}");
                //return RedirectToAction("Dashboard", "Home", new { name = username});
            }
            catch
            {
                return View(model);
            }
        }
    }
}
