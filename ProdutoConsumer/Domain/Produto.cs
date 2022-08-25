using PagtelConsumer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoConsumer.Domain
{
    public class Produto
    {
        Conexao conexao = new Conexao();

        SqlCommand cmd = new SqlCommand();

        public String mensagem = "";

        public Produto(String NomeProduto, String Preco)
        {
            //Comando do Sql
            cmd.CommandText = "insert into produto (NomeProduto, Preco) values (@NomeProduto, @Preco) ";

            //Parametro
            cmd.Parameters.AddWithValue("@NomeProduto", NomeProduto);
            cmd.Parameters.AddWithValue("@Preco", Preco);

            //Conectar com banco

            try
            {
                cmd.Connection = conexao.conectar();
                //Executar o comando
                cmd.ExecuteNonQuery();

                //Desconectar
                conexao.desconectar();

                this.mensagem = "Produto cadastrado com sucesso";
            }
            catch (SqlException e)
            {
                this.mensagem = "Erro ao Logar no banco de dados";
            }
        }
    }
}

