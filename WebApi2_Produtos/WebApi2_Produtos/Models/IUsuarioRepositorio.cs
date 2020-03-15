using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi2_Produtos.Models
{
    public interface IUsuarioRepositorio
    {
        bool Get(Usuario usuario);
        bool Update(Usuario usuario);
    }
}
