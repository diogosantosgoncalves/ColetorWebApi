using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2_Produtos.Models
{
    public class Usuario
    {
        //Testando2
        //teste
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public Boolean Deslogado { get; set; }
        public Boolean Inativo { get; set; }
    }
}