using System;

namespace WebApi2_Produtos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Setor { get; set; }
        public Boolean Inativo { get; set; }
        public int Quantidade { get; set; } 
    }
}