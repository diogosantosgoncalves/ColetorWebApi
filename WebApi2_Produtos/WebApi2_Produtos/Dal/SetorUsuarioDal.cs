using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using WebApi2_Produtos.Models;
using System.Data.SqlClient;

namespace WebApi2_Produtos.Dal
{
    public class SetorUsuarioDal
    {
        SqlDataReader SqlDataReader;
        ConexaoSQL ConexaoSQL;
        protected static string GetStringConexao()
        {

            return ConfigurationManager.ConnectionStrings["conexaoSQLServer"].ConnectionString;
        }
        public static List<SetorUsuario> GetSetorUsuario()
        {
            List<SetorUsuario> lista_setorusuario = new List<SetorUsuario>();
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                //ConexaoSQL.conectar();
                using (SqlCommand sqlcommand = new SqlCommand("select * from SetorUsuario", con))
                {
                    using (SqlDataReader sqlDataReader = sqlcommand.ExecuteReader())
                    {
                        if (sqlDataReader != null)
                        {
                            while (sqlDataReader.Read())
                            {
                                var setorUsuario = new SetorUsuario();
                                setorUsuario.setorusuario_id = int.Parse(sqlDataReader["setorusuario_id"].ToString());
                                setorUsuario.setorusuario_setor_id = int.Parse(sqlDataReader["setorusuario_setor_id"].ToString());
                                setorUsuario.setorusuario_usu_id = int.Parse(sqlDataReader["setorusuario_usu_id"].ToString());
                                lista_setorusuario.Add(setorUsuario);
                            }
                        }
                        return lista_setorusuario;
                    }
                }
            }
        }
        public static List<String> BuscarPermissao(String nome)
        {
            try
            {
                string sql = "select s.setor_nome from setorusuario su inner join setor s on" +
                " su.setorusuario_setor_id = s.setor_id inner join Usuario u on su.setorusuario_usu_id = u.usu_id " +
                " where u.usu_nome = @nome";
                List<String> setores = new List<String>();
                using (SqlConnection sqlConnection = new SqlConnection(GetStringConexao()))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@nome", nome);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read() == true)
                        {
                            setores.Add(sqlDataReader["setor_nome"].ToString());
                        }
                        return setores;

                    }
                    sqlConnection.Close();
                }
                return setores;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }
    }
}