using GerenciaControler.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaControler.Helper
{
    public class Session : ISessionH
    {
        private readonly IHttpContextAccessor _HttpContex;

        public Session(IHttpContextAccessor httpContext)
        {
            _HttpContex = httpContext;
        }
        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _HttpContex.HttpContext.Session.GetString("SessionUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
                return null;
            UsuarioModel teste = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(UsuarioModel usuario)
        {
            string valoresUsuario = JsonConvert.SerializeObject(usuario);
            _HttpContex.HttpContext.Session.SetString("SessionUsuarioLogado", valoresUsuario);
        }

        public void RemoverSessaoDoUsuario()
        {
            _HttpContex.HttpContext.Session.Remove("SessionUsuarioLogado");
        }
    }
}
