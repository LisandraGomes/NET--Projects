using GerenciaControler.Data;
using GerenciaControler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaControler.Repositorio
{
    public class RepositorioUsuario : UsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public RepositorioUsuario(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioUp = BuscaId(usuario.Id);

            if (usuarioUp == null)
                throw new SystemException("Erro na Atualização. Tente novamente mais tarde.");

            //Armazena Senhas Antigas
            if (usuario.Senha != null) 
            {
                string listaSenha = usuarioUp.SenhasAntigas;

                usuario.SetSenhaHash();

                usuarioUp.Senha = usuario.Senha;

                List<String> SenhasOld = new List<String>();

                if (listaSenha != null)
                {
                    foreach (var senha in listaSenha.Split(';'))
                        if(senha != "")
                            SenhasOld.Add(senha);
                    if (!SenhasOld.Contains(usuario.Senha))
                    {
                        usuario.SetSenhaHash();
                        usuarioUp.SenhasAntigas += usuario.Senha + ";";
                    }
                }

            }

            if(usuario.Admin)
                usuarioUp.Matricula = usuario.Matricula;
            if(usuario.Nome!=null && usuario.Nome != usuarioUp.Nome)
                usuarioUp.Nome = usuario.Nome;
            if (usuario.Cargo != null && usuario.Cargo != usuarioUp.Cargo)
                usuarioUp.Cargo = usuario.Cargo;
            if (usuario.DataNascimento != null && usuario.DataNascimento != usuarioUp.DataNascimento)
                usuarioUp.DataNascimento = usuario.DataNascimento;
            if (usuario.Admin != null && usuario.Admin != usuarioUp.Admin)
                usuarioUp.Admin = usuario.Admin;

            var idade = (DateTime.Now.Year - usuarioUp.DataNascimento.Year);            //22

            var fezAniversarioEsteAno = (DateTime.Now.Month <= usuarioUp.DataNascimento.Month && DateTime.Now.Day <= usuarioUp.DataNascimento.Day); 


            var idadeAtual = fezAniversarioEsteAno ? idade : idade - 1;

            usuarioUp.Idade = idadeAtual;




            _bancoContext.Usuarios.Update(usuarioUp);
            _bancoContext.SaveChanges();

            return usuarioUp;
        }

        public UsuarioModel BuscaId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(a => a.Id == id);
        }

        public UsuarioModel BuscarLogin(string login)
        {
            UsuarioModel retornando;
            retornando = _bancoContext.Usuarios.FirstOrDefault(a => a.Matricula.ToLower().Trim() == login.ToLower().Trim());

            return retornando;
        }

        public UsuarioModel BuscarMatricula(string matricula)
        {
            return _bancoContext.Usuarios.FirstOrDefault(a => a.Matricula.ToLower().Trim() == matricula.ToLower().Trim());
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }
        public UsuarioModel Criar(UsuarioModel usuario)
        {
            //Gravar no BANCO Criar novo usuario
            var idade = (DateTime.Now.Year - usuario.DataNascimento.Year);
            usuario.Idade = ((DateTime.Now.Month <= usuario.DataNascimento.Month && DateTime.Now.Day <= usuario.DataNascimento.Day) 
                            || (DateTime.Now.Month <= usuario.DataNascimento.Month) ? usuario.Idade = idade - 1 : usuario.Idade = idade);

            usuario.SetSenhaHash();

            if (usuario.Senha != null)
            {
                usuario.SenhasAntigas = usuario.Senha + ";";
            }
            else
            {
                usuario.Senha = "12345";
                usuario.SetSenhaHash();
            }

            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();

            return usuario;

        }

        public bool Excluir(int id)
        {
            UsuarioModel usuarioDl = BuscaId(id);

            if (usuarioDl == null)
                throw new SystemException("Erro na Exclusão. Tente novamente mais tarde.");

            _bancoContext.Usuarios.Remove(usuarioDl);
            _bancoContext.SaveChanges();

            return true;
        }


    }
}
