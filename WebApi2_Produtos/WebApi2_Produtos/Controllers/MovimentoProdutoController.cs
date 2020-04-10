using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2_Produtos.Models;

namespace WebApi2_Produtos.Controllers
{
    public class MovimentoProdutoController : ApiController
    {
        static readonly IMovimentoProdutoRepositorio repositorio = new MovimentoProdutoRepositorio();

        public void Post(List<MovimentoProduto> mv)
        {
            repositorio.InserirMovimentoProduto(mv);
        }
    }
}
