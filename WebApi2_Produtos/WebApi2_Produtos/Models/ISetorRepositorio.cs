﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi2_Produtos.Models
{
    public interface ISetorRepositorio
    {
        bool Get(Setor setor);
        bool Update(Setor setor);

    }
}
