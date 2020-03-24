using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2_Produtos.Dal;

namespace WebApi2_Produtos.Models
{
    public class SetorUsuarioRepositorio: ISetorUsuarioRepositorio
    {
        private List<SetorUsuario> lista_setorusuario;
        SetorUsuarioDal setorusuarioDao;
        private int _nextId = 1;
        public SetorUsuarioRepositorio()
        {
            //ProdutosDao.GetProduto();
        }
        private void InicializaDados()
        {
            SetorUsuarioDal.GetSetorUsuario();
        }
        public List<String> Get(String nome)
        {
            return SetorUsuarioDal.BuscarPermissao(nome);
        }

        public IEnumerable<SetorUsuario> GetAll()
        {
            return SetorUsuarioDal.GetSetorUsuario();
        }
    }
}