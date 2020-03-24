using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApi2_Produtos.Models
{
    public class ProdutosDao
    {
        SqlCommand SqlCommand;
        SqlDataReader SqlDataReader;
        ConexaoSQL ConexaoSQL;
        protected static string GetStringConexao()
        {

            return ConfigurationManager.ConnectionStrings["conexaoSQLServer"].ConnectionString;
        }


        public static List<Produto> GetProduto()
        {
            List<Produto> lista_produtos = new List<Produto>();
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                //ConexaoSQL.conectar();
                using (SqlCommand sqlcommand = new SqlCommand("select * from Produto", con))
                {
                    using (SqlDataReader sqlDataReader = sqlcommand.ExecuteReader())
                    {
                        if (sqlDataReader != null)
                        {
                            while (sqlDataReader.Read())
                            {
                                var produto = new Produto();
                                produto.Id = int.Parse(sqlDataReader["prod_codigo"].ToString());
                                produto.Nome = sqlDataReader["prod_nome"].ToString();
                                produto.Setor = sqlDataReader["prod_setor"].ToString();
                                produto.Quantidade = int.Parse(sqlDataReader["prod_quant"].ToString());
                                produto.Inativo = sqlDataReader.GetBoolean(3);
                                produto.setor_id = int.Parse(sqlDataReader["setor_id"].ToString());
                                //produto.setor.setor_id = 1;
                                //produto.setor.setor_id = int.Parse(sqlDataReader["setor_id"].ToString());
                                //produto.setor.setor_id = int.Parse(sqlDataReader["prod_codigo"].ToString());
                                lista_produtos.Add(produto);
                            }
                        }
                        return lista_produtos;
                    }
                }
            }
        }
        public static void Atualizar_Produto(int id, Produto produto)
        {
            using(SqlConnection sqlConnection = new SqlConnection(GetStringConexao()))
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = new SqlCommand("update Produto set prod_quant = @quant where prod_codigo = @codigo", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@quant", produto.Quantidade);
                    sqlCommand.Parameters.AddWithValue("@codigo", id);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    sqlCommand.Parameters.Clear();
                }
                sqlConnection.Close();
            }
            //return true;
        }
        public void SalvarProduto(string nome_produto, string setor)
        {
            char pr_inativo = '0';
            int pr_quant = 0;
            using (SqlConnection sqlConnection = new SqlConnection(GetStringConexao()))
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = new SqlCommand("insert into Produto(prod_nome,prod_setor,prod_inativo,prod_quant) values (@nomeprod,@senha,@inativo,@quant);", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@nomeprod", nome_produto);
                    sqlCommand.Parameters.AddWithValue("@senha", setor);
                    sqlCommand.Parameters.AddWithValue("@inativo", pr_inativo);
                    sqlCommand.Parameters.AddWithValue("@quant", pr_quant);

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    sqlCommand.Parameters.Clear();
                }
                sqlConnection.Close();
            }
        }
        public static Produto BuscarProduto(int codigo)
        {
            try
            {
                Produto produto = new Produto();
                using(SqlConnection sqlConnection = new SqlConnection(GetStringConexao()))
                {
                    sqlConnection.Open();
                    using(SqlCommand sqlCommand = new SqlCommand("select * from Produto where prod_codigo =  @codigo", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@codigo", codigo);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        if (sqlDataReader.Read() == true)
                        {

                            produto.Id = int.Parse(sqlDataReader[0].ToString());
                            produto.Nome = sqlDataReader[1].ToString();
                            produto.Setor = sqlDataReader[2].ToString();
                            produto.Quantidade = int.Parse(sqlDataReader["prod_quant"].ToString());
                            produto.Inativo = sqlDataReader.GetBoolean(3);
                            //produto.setor.setor_id = int.Parse(sqlDataReader["setor_id"].ToString());

                            return produto;
                            
                        }
                    sqlCommand.Parameters.Clear();
                    }
                    sqlConnection.Close();
                }
                return produto;
            }

            catch (SqlException ex)
            {
                return null;
            }
        }

        public void AtivarProduto(string nome)
        {
            try
            {
                Produto produto = new Produto();
                SqlCommand.CommandText = "update Produto set prod_inativo = 0 where prod_nome =  @produto";
                SqlCommand.Parameters.AddWithValue("@produto", nome);
                SqlCommand.Connection = ConexaoSQL.conectar();
                SqlDataReader = SqlCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                //ex.Message;
            }
            finally
            {
                SqlCommand.Parameters.Clear();
                ConexaoSQL.desconectar();
                SqlDataReader.Close();
            }
        }
        public void RemoverProduto(int codigo)
        {
            try
            {
                Produto produto = new Produto();
                SqlCommand.CommandText = "delete from Produto where prod_codigo =  @codigo";
                SqlCommand.Parameters.AddWithValue("@produto", codigo);
                SqlCommand.Connection = ConexaoSQL.conectar();
                SqlDataReader = SqlCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                //ex.Message;
            }
            finally
            {
                SqlCommand.Parameters.Clear();
                ConexaoSQL.desconectar();
                SqlDataReader.Close();
            }
        }
    }
}
    