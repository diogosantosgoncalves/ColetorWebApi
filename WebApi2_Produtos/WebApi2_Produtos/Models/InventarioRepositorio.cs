using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2_Produtos.Dal;
using WebApi2_Produtos.Models;

namespace WebApi2_Produtos.Models
{
    public class InventarioRepositorio: IInventarioRepositorio
    {
        public InventarioRepositorio()
        {

        }
        public int Get()
        {
            return InventarioDal.GetInventarioAberto();
        }
    }
}