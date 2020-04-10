using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi2_Produtos.Dal;

namespace WebApi2_Produtos.Models
{
    public interface IInventarioRepositorio
    {
        int Get();
    }
}
