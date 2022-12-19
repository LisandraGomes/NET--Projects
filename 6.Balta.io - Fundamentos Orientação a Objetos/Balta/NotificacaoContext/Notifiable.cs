using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balta.NotificacaoContext
{
    public abstract class Notifiable
    { 
        public List<Notificacao> Notificacoes { get; set; }

        public Notifiable()
        {
            Notificacoes = new List<Notificacao>();
        }
        public void AddNotificacao(Notificacao notificacoes)
        {
            Notificacoes.Add(notificacoes);
        }
        public void AddNotificacoes(IEnumerable<Notificacao> notificacoes)
        {
            Notificacoes.AddRange(notificacoes);
        }

        public bool IsInvalid => Notificacoes.Any();
    }
}
