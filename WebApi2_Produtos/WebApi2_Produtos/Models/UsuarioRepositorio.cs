using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2_Produtos.Models
{
    public class UsuarioRepositorio: IUsuarioRepositorio
    {
        public bool Get(Usuario usuario)
        {
           return UsuariosDao.BuscarUsuário(usuario);
           ///return usuario;
        }
        public void Update(int id)
        {
            UsuariosDao.Ativa_Usuario(id);
        }
    }
}