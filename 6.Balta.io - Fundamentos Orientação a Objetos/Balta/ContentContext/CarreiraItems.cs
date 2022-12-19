using Balta.Compartilhado;
using Balta.NotificacaoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balta.ContentContext
{
    public class CarreiraItems : Base
    {
        public CarreiraItems(int ordem, string titulo, string descricao, Curso cursos)
        {
            if (cursos == null)
                AddNotificacao(new Notificacao("Curso", "Curso Inválido!"));

            Ordem = ordem;
            Titulo = titulo;
            Descricao = descricao;
            Cursos = cursos;
        }

        public int Ordem { get; set; }
        public string Titulo { get; set; }

        public string Descricao { get; set; }
        public Curso Cursos { get; set; }
    }
}
