using GerenciaControler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaControler.Repositorio
{
    public interface UsuarioRepositorio
    {
        UsuarioModel BuscarLogin(string login);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel BuscaId(int id);
        UsuarioModel Criar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Excluir(int id);
        UsuarioModel BuscarMatricula(string matricula);

    }
}
