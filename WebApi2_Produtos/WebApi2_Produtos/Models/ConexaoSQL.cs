using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace WebApi2_Produtos.Models
{
    public class ConexaoSQL
    {
        SqlConnection con = new SqlConnection();

        public ConexaoSQL()
        {
            con.ConnectionString = @"Data Source=Localhost\SQL2014;Initial Catalog=ColetorApp;Persist Security Info=True;User ID=sa;Password=senha";
        }

        public SqlConnection conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }

}
