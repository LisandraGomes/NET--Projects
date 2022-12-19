using Balta.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balta.ContentContext
{
        public class Module : Base
        {
            public Module()
            {
                Aula = new List<Aulas>();
            }
            public int Ordem { get; set; }
            public string Titulo { get; set; }

            public IList<Aulas> Aula { get; set; }
        }
    }

