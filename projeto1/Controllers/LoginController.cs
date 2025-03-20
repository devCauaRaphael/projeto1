using Microsoft.AspNetCore.Mvc;
using projeto1.Repositorio;

namespace projeto1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Login(string senha, string email)
        {
            var usuario = _usuarioRepositorio.ObterUsuario(email);
            if (usuario != null && usuario.senha == senha) 
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Email ou senha inválidos");

            return View();
        }
    }

}
