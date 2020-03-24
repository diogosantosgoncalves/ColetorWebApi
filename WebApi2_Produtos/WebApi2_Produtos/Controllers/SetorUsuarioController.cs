using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2_Produtos.Models;

namespace WebApi2_Produtos.Controllers
{
    public class SetorUsuarioController : ApiController
    {
        static readonly ISetorUsuarioRepositorio repositorio = new SetorUsuarioRepositorio();


        public IEnumerable<SetorUsuario> GetAll()
        {
            return repositorio.GetAll();
        }
        public List<String> GetPermissao(String nome)
        {
            List<String> item = repositorio.Get(nome);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }



    }
}
