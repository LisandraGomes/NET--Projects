using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Aplication.DTOs
{
    public class ProdutoDto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public decimal Valor { get; private set; }
        public string Descricao { get; private set; }
        public int QtdDisponivel { get; set; }
        public string Imagem { get; private set; }//caminho da imagem no sistema
        public decimal Peso { get; set; }
        public string Tamanho { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
    }
}
