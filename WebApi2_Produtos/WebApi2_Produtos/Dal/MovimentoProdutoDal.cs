using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApi2_Produtos.Models;

namespace WebApi2_Produtos.Dal
{
    public class MovimentoProdutoDal
    {
        SqlCommand SqlCommand;
        SqlDataReader SqlDataReader;
        ConexaoSQL ConexaoSQL;
        protected static string GetStringConexao()
        {

            return ConfigurationManager.ConnectionStrings["conexaoSQLServer"].ConnectionString;
        }

        public static void SalvarMovimentoProduto(List<MovimentoProduto> movimentoProdutos)
        {
            int pr_quant = 0;
            using (SqlConnection sqlConnection = new SqlConnection(GetStringConexao()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("insert into movimento_produto(mp_inventario,mp_produto,mp_produto_quant) values (@inventario,@produto,@quant);", sqlConnection))
                {
                    foreach(var mov in movimentoProdutos)
                    {
                        sqlCommand.Parameters.AddWithValue("@inventario", mov.mp_inventario);
                        sqlCommand.Parameters.AddWithValue("@produto", mov.mp_produto);
                        sqlCommand.Parameters.AddWithValue("@quant", mov.mp_quant);

                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        //sqlCommand.Parameters.cl
                        sqlDataReader.Close();
                        sqlCommand.Parameters.Clear();
                    }

                }
                sqlConnection.Close();
            }
        }
    }
}