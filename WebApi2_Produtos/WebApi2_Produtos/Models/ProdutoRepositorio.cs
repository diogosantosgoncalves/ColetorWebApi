using System;
using System.Collections.Generic;
using WebApi2_Produtos.Controllers;
using System.Data.SqlClient;

namespace WebApi2_Produtos.Models
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private List<Produto> lista_produtos;
        ProdutosDao produtosDao;
        private int _nextId = 1;
       
        public ProdutoRepositorio()
        {
            //ProdutosDao.GetProduto();
        }
        private void InicializaDados()
        {
             ProdutosDao.GetProduto();
        }
        public Produto Add(Produto item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("item");
            }
            produtosDao.SalvarProduto(item.Nome,item.Setor);
            //item.Id = _nextId++;
            //item.Add(item);
            return item;
        }

        public Produto Get(int id)
        {

            return ProdutosDao.BuscarProduto(id);
            //return produtos.Find(p => p.Id == id);
        }

        public IEnumerable<Produto> GetAll()
        {
            return ProdutosDao.GetProduto();
            //return produtos;
        }

        public void Remove(int id)
        {
            produtosDao.RemoverProduto(id);
            //produtos.RemoveAll(p => p.Id == id);
        }

        public bool Update(Produto item)
        {
            if( item == null)
            {
                throw new ArgumentNullException("item");
            }
            
            //item = produtosDao.BuscarProduto(item.Id);

            //int index = produtosDao.BuscarProduto(item);
            if(item != null)
            {
                ProdutosDao.Atualizar_Produto(item.Id, item);
                return true;
            }
            else
            {
                //produtosDao.RemoverProduto(item.Id);
                return false;
            }

        }
    
    }
}