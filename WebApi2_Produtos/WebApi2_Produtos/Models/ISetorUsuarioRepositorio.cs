using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi2_Produtos.Models
{
    public interface ISetorUsuarioRepositorio
    {
        IEnumerable<SetorUsuario> GetAll();
        List<String> Get(String nome);

    }
}
