using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApi2_Produtos.Models
{
    public class UsuariosDao
    {
        protected static string GetStringConexao()
        {

            return ConfigurationManager.ConnectionStrings["conexaoSQLServer"].ConnectionString;
        }

        public static bool BuscarUsuário(Usuario usuario)
        {
            using(SqlConnection sqlConnection = new SqlConnection(GetStringConexao()))
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = new SqlCommand("Select * from Usuario where usu_nome = @nome and usu_senha = @senha", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@nome", usuario.Id);
                    sqlCommand.Parameters.AddWithValue("@senha", usuario.Id);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read() == true)
                    {
                        sqlCommand.Parameters.Clear();
                        return true;

                    }
                    else
                    {
                        sqlCommand.Parameters.Clear();
                        sqlConnection.Close();
                        return false;

                    }
                    
                }

            }
        }

        public static void Ativa_Usuario(int id)
        {
            using(SqlConnection sqlConnection = new SqlConnection(GetStringConexao()))
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = new SqlCommand("update Usuario set usu_deslogado = 0 where usu_id = @id", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    sqlCommand.Parameters.Clear();
                }
                sqlConnection.Close();
            }
        }
    }
}