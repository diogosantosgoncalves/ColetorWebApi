using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2_Produtos.Dal;
using WebApi2_Produtos.Models;

namespace WebApi2_Produtos.Models
{
    public class MovimentoProdutoRepositorio: IMovimentoProdutoRepositorio
    {
        public MovimentoProdutoRepositorio()
        {

        }
        public void InserirMovimentoProduto(List<MovimentoProduto> list)
        {
            MovimentoProdutoDal.SalvarMovimentoProduto(list);
        }

    }
}