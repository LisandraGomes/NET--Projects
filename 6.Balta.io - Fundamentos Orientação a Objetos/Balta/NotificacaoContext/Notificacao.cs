using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balta.NotificacaoContext
{
    public sealed class Notificacao
    {
        public Notificacao()
        {
       
        }
        public Notificacao(string propriedade, string mensagem)
        {
            Propriedade = propriedade;
            Mensagem = mensagem;
        }

        public string Propriedade { get; set; }

        public string Mensagem { get; set; }
    }
}
