using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagtelConsumer
{
    public class Conexao
    {

        SqlConnection con = new SqlConnection();

        //Construtor
        public Conexao()
        {
            con.ConnectionString = "Data Source=PAGTEL38\\SQLEXPRESS;Initial Catalog=master;User ID=sa;Password=Silvia567890@";
        }
        //Conexao Banco de dados
        public SqlConnection conectar()
        {

            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        //Desconectar Banco de dados
        public void desconectar()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
