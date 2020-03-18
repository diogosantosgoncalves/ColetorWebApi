using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApi2_Produtos.Models
{
    public class SetorDao
    {
        protected static string GetStringConexao()
        {

            return ConfigurationManager.ConnectionStrings["conexaoSQLServer"].ConnectionString;
        }

        public static bool BuscarSetor(Setor setor)
        {
            using (SqlConnection sqlConnection = new SqlConnection(GetStringConexao()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("Select * from Setor where setor_nome = @nome", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@nome", setor.setor_nome);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read() == true)
                    {
                        sqlCommand.Parameters.Clear();
                        sqlConnection.Close();
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

        public static void Ativa_Setor(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(GetStringConexao()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("update Setor set setor_id = 0 where usu_id = @id", sqlConnection))
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