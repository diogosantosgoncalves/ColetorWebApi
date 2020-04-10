using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2_Produtos.Models
{
    public class MovimentoProduto
    {
        public int mp_id { get; set; }
        public int mp_inventario { get; set; }
        public string mp_produto { get; set; }
        public int mp_quant { get; set; }

    }
}