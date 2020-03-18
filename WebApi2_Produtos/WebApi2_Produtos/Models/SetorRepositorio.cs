using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2_Produtos.Models
{
    public class SetorRepositorio
    {
        public bool Get(Setor setor)
        {
            return SetorDao.BuscarSetor(setor);
            ///return usuario;
        }
        public bool Update(Setor setor)
        {
            if (SetorDao.BuscarSetor(setor) == true)
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