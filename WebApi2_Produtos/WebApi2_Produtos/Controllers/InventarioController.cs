using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2_Produtos.Models;

namespace WebApi2_Produtos.Controllers
{
    public class InventarioController : ApiController
    {
        static readonly IInventarioRepositorio repositorio = new InventarioRepositorio();

        public int Get()
        {
            return repositorio.Get();
        }
    }
}
