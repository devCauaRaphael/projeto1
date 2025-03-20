using Microsoft.AspNetCore.Mvc;
using projeto1.Models;
using projeto1.Repositorio;

namespace projeto1.Controllers
{
    public class LoginController : Controller
    {
        /*construtor*/
        private readonly UsuarioRepositorio _usuarioRepositorio;
        public LoginController(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;

        }
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
        public IActionResult Cadastro() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid) 
            {
                _usuarioRepositorio.AdicionarUsuario(usuario);
                return RedirectToAction("Login");

            }
            return View(usuario);
        }
    }

}
