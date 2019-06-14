using MeuTrabalho.Contracts;
using MeuTrabalho.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeuTrabalho.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
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
            string user = _accountRepository.Login(model.Email, model.Password);

            if (user != null)
            {
                return Redirect($"/Home/Dashboard?name={user}");
            }
            else
            {
                TempData["message"] = "Combinação de usuário e senha não encontrados.";

                return View();
            }
        }
    }
}
