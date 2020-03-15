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
        public bool Update(Usuario usuario)
        {
            if (UsuariosDao.BuscarUsuário(usuario) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
            //UsuariosDao.Ativa_Usuario(id);
        }
    }
}