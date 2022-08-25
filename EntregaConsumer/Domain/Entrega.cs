using PagtelConsumer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregaConsumer.Domain
{
    public class Entrega
    {
        Conexao conexao = new Conexao();

        SqlCommand cmd = new SqlCommand();

        public String mensagem = "";

        public Entrega(String DataEntrega, String Status, int PedidoID)
        {
            //Comando do Sql
            cmd.CommandText = "insert into entrega (DataEntrega, Status, PedidoID) values (@DataEntrega, @Status, @PedidoID) ";

            //Parametro
            cmd.Parameters.AddWithValue("@DataEntrega", DataEntrega);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@PedidoID", PedidoID);

            //Conectar com banco

            try
            {
                cmd.Connection = conexao.conectar();
                //Executar o comando
                cmd.ExecuteNonQuery();

                //Desconectar
                conexao.desconectar();

                this.mensagem = "Pedido cadastrado com sucesso";
            }
            catch (SqlException e)
            {
                this.mensagem = "Erro ao Logar no banco de dados";
            }
        }
    }
}
