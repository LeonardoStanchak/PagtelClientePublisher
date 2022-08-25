using PagtelConsumer;
using PagtelConsumer.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoConsumer.Domain
{
    public class Pedido
    {
        Conexao conexao = new Conexao();

        SqlCommand cmd = new SqlCommand();

        public String mensagem = "";

        public Pedido(String DataPedido, String NumeroPedido, int ClienteID, int ProdutoId)
        {
            //Comando do Sql
            cmd.CommandText = "insert into pedido (DataPedido, NumeroPedido, ClienteID, ProdutoId) values (@DataPedido, @NumeroPedido, @ClienteID, @ProdutoId) ";

            //Parametro
            cmd.Parameters.AddWithValue("@DataPedido", DataPedido);
            cmd.Parameters.AddWithValue("@ProdutoId", ProdutoId);
            cmd.Parameters.AddWithValue("@ClienteID", ClienteID);
            cmd.Parameters.AddWithValue("@NumeroPedido", NumeroPedido);

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

