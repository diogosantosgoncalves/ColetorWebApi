using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using WebApi2_Produtos.Dal;
using WebApi2_Produtos.Models;

namespace WebApi2_Produtos.Dal
{
    public class InventarioDal
    {
        SqlDataReader sqldataReader;
        ConexaoSQL ConexaoSQL;

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["conexaoSQLServer"].ConnectionString;
        }
        public static int GetInventarioAberto()
        {
            int codigo = 0;
            Inventario inventario = new Inventario();
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                //ConexaoSQL.conectar();
                using (SqlCommand sqlcommand = new SqlCommand("select * from Inventario where inv_dtabertura is not null and inv_dtfechamento is null", con))
                {
                    using (SqlDataReader sqlDataReader = sqlcommand.ExecuteReader())
                    {
                        if (sqlDataReader != null)
                        {
                            if (sqlDataReader.Read())
                            {
                                codigo = int.Parse(sqlDataReader["inv_id"].ToString());
                                //inventario.inv_dtabertura = sqlDataReader.GetDateTime(1);
                                //inventario.inv_dtfechamento = sqlDataReader["inv_dtfechamento"].ToString().Length > 0 ? DateTime.Parse(sqlDataReader["inv_dtfechamento"].ToString()) : DateTime.MinValue;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                        return codigo;
                    }

                }
            }
        }
    }
}