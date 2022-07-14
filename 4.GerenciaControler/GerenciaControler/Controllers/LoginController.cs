using GerenciaControler.Models;
using GerenciaControler.Helper;
using GerenciaControler.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GerenciaControler.Controllers
{
    public class LoginController : Controller
    {

        private readonly UsuarioRepositorio _UsuarioRepositorio;
        private readonly ISessionH _sessao;
        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoDoUsuario() != null && _sessao.BuscarSessaoDoUsuario().Admin == true)
                return RedirectToAction("Index", "Usuarios");
            if (_sessao.BuscarSessaoDoUsuario() != null && _sessao.BuscarSessaoDoUsuario().Admin != true)
                return RedirectToAction("EditarUsuario", "Usuarios");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();

            return RedirectToAction("Index", "Login");
        }

        public LoginController(UsuarioRepositorio usuarioRepositorio, ISessionH session)
        {
            _UsuarioRepositorio = usuarioRepositorio;
            _sessao = session;
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _UsuarioRepositorio.BuscarLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            if (usuario.Admin)
                            {
                                return RedirectToAction("Index", "Usuarios", usuario);
                            }
                            if (!usuario.Admin)
                            {
                                return RedirectToAction("EditarUsuario", "Usuarios", usuario);
                            }
                        }
                        else
                        {
                            TempData["MensagemErro"] = "Senha Inválida! " +
                                                          "Verifique as informações e tente novamente!";
                        }
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Usuário Inválido! " +
                                                      "Verifique as informações e tente novamente!";
                    }
                }
                    
                return View("Index");
                
            }
            catch (SystemException error)
            {
                TempData["MensagemErro"] = "Login deu erro, verifique as informações e tente novamente!";
                return RedirectToAction("Index");
            }
        }
    }
}
