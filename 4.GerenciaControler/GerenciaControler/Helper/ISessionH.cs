using GerenciaControler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaControler.Helper
{
    public interface ISessionH
    {

            void CriarSessaoUsuario(UsuarioModel usuario);
            void RemoverSessaoDoUsuario();

            UsuarioModel BuscarSessaoDoUsuario();
        
    }

}

