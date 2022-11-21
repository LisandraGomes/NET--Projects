using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Aplication.DTOs
{
    public class CompraDto
    {
        public int Id { get; private set; }
        public int IdProduto { get; private set; }
        public int IdPessoa { get; private set; }
        public DateTime Data { get; private set; }
    }
}
