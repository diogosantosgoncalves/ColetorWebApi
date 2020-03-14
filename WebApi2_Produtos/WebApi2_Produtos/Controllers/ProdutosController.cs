using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2_Produtos.Models;

namespace WebApi2_Produtos.Controllers
{
    public class ProdutosController : ApiController
    {
        static readonly IProdutoRepositorio repositorio = new ProdutoRepositorio();

        public IEnumerable<Produto> GetAllProdutos()
        {
            
            //WebApi2_Produtos.Models.
            //ProdutosDao produtosDao = new ProdutosDao();
            
            return repositorio.GetAll();
        }

        public Produto GetProduto(int id)
        {
            Produto item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Produto> GetProdutosPorCategoria(string categoria)
        {
            return repositorio.GetAll().Where(
                p => string.Equals(p.Setor, categoria, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostProduto(Produto item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<Produto>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        /*public void PutProduto(int id, Produto produto)
        {
            produto.Id = id;
            if (!repositorio.Update(produto))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }*/
        public void PutProduto(Produto produto)
        {
            //produto.Id = id;
            if (!repositorio.Update(produto))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repositorio.Update(produto);

        }

        public void DeleteProduto(int id)
        {
            /*using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53557/api/");
                var deleteTask = client.DeleteAsync("produtos/" + id.ToString());
                repositorio.Get(id);
                repositorio.Remove(id);
            }
            /* */
            Produto item = repositorio.Get(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repositorio.Remove(id);
        }
    }
}
