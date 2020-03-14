using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2_Produtos.Models;

namespace WebApi2_Produtos.Controllers
{
    public class UsuarioController : ApiController
    {
        static readonly IUsuarioRepositorio repositorio = new UsuarioRepositorio();

        public void GetUsuario(Usuario usuario)
        {
            repositorio.Get(usuario);
        }
        public void PutUsuario(int id)
        {
            repositorio.Update(id);
        }
    }
}
