using System;

namespace WebApi2_Produtos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int setor_id { get; set; }
        public string Nome { get; set; }
        public string Setor { get; set; }
        public Boolean Inativo { get; set; }
        public int Quantidade { get; set; }
        // public virtual Setor setor { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Setor objAsPart = obj as Setor;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return setor_id;
        }
        public bool Equals(Setor setor)
        {
            if (setor == null) return false;
            return (this.Setor.Equals(setor.setor_id));
        }

    }
}