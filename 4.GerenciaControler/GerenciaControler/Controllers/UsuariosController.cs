using GerenciaControler.Helper;
using GerenciaControler.Models;
using GerenciaControler.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaControler.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuarioRepositorio _UsuarioRepositorio;
        private readonly ISessionH _sessao;

        public UsuariosController(UsuarioRepositorio usuarioRepositorio, ISessionH session)
        {
            _UsuarioRepositorio = usuarioRepositorio;
            _sessao = session;
        }
        public IActionResult Index()
        {
            var usuarios = _UsuarioRepositorio.BuscarTodos();

            return View(usuarios);
        }

        public IActionResult CriarUsuario()
        {
            return View();
        }

        public IActionResult EditarUsuario(int id)
        {
            UsuarioModel usuario = _UsuarioRepositorio.BuscaId(id);
            return View(usuario);
        }
        public IActionResult EditarUsuarioAdmin(int id)
        {
            UsuarioModel usuario = _UsuarioRepositorio.BuscaId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            UsuarioModel matricula = _UsuarioRepositorio.BuscarMatricula(usuario.Matricula);
            bool MatriculaValida = true;

            if (matricula != null)
            {
               MatriculaValida = false ;
            }

            try { 
                if (ModelState.IsValid && MatriculaValida)
                {                    
                    _UsuarioRepositorio.Criar(usuario);
                    TempData["MensagemSucesso"] = $"Usuario {usuario.Nome}, Criado com sucesso!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "Matricula Inválida! " +
                                               "Esta matrícula já está sendo usada.";
                    return View("CriarUsuario", usuario);
                }

            }
            catch(SystemException error)
            {
                TempData["MensagemErro"] = $"Operação Falhou! erro: { error.Message}";
                return RedirectToAction("Index");
            }
}
        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _UsuarioRepositorio.Atualizar(usuario);

                    if (usuario.Admin || _sessao.BuscarSessaoDoUsuario().Admin == true )
                    {
                        TempData["MensagemSucesso"] = $"{usuario.Nome}, Editado com sucesso!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["MensagemSucesso"] = $"Editado com sucesso!";
                        return View("EditarUsuario", _UsuarioRepositorio.BuscaId(usuario.Id));
                    }
                }
                else
                {
                    if(usuario.Admin)
                        return View("EditarUsuarioAdmin", _UsuarioRepositorio.BuscaId(usuario.Id));
                    else
                    {
                        return View("EditarUsuario", _UsuarioRepositorio.BuscaId(usuario.Id));
                    }
                }
            }
            catch(SystemException error)
            {
                TempData["MensagemErro"] = $"Operação Falhou! erro: { error.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Excluir(int id)
        {
            try
            {
                bool apagou = _UsuarioRepositorio.Excluir(id);

                if (apagou) { TempData["MensagemSucesso"] = "Exclusão Realizada!"; }
                else { TempData["MensagemSucesso"] = "Exclusão Não Realizada!"; }

                return RedirectToAction("Index");
            }
            catch (SystemException error)
            {
                TempData["MensagemSucesso"] = $"Erro na Exclusão, erro: {error.Message}";
                return RedirectToAction("Index");
            }

        }
        public IActionResult ExcluirUsuario(int id)
        {
            UsuarioModel usuario = _UsuarioRepositorio.BuscaId(id);

            return View(usuario);
        }

    }
}
