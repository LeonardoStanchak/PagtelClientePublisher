using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagtelConsumer.Domain
{
    public class Cliente
    {

        Conexao conexao = new Conexao();

        SqlCommand cmd = new SqlCommand();

        public String mensagem = "";

        public Cliente(String Nome, String Cpf, String DataNascimento, String Cep, String Endereco, String NumeroEndereco, String Complemento, String Referencia)
        {
            //Comando do Sql
            cmd.CommandText = "insert into cliente (nome, cpf, dataNascimento, cep, Endereco, numeroEndereco, complemento, referencia) values (@nome, @cpf, @dataNascimento, @cep, @Endereco, @numeroEndereco, @complemento, @referencia) ";

            //Parametro
            cmd.Parameters.AddWithValue("@Nome", Nome) ;
            cmd.Parameters.AddWithValue("@Cpf", Cpf);
            cmd.Parameters.AddWithValue("@DataNascimento", DataNascimento);
            cmd.Parameters.AddWithValue("@Cep", Cep);
            cmd.Parameters.AddWithValue("@Endereco", Endereco);
            cmd.Parameters.AddWithValue("@NumeroEndereco", NumeroEndereco);
            cmd.Parameters.AddWithValue("@Complemento", Complemento);
            cmd.Parameters.AddWithValue("@Referencia", Referencia);

            //Conectar com banco

            try
            {
                cmd.Connection = conexao.conectar();
                //Executar o comando
                cmd.ExecuteNonQuery();

                //Desconectar
                conexao.desconectar();

                this.mensagem = "Cliente cadastrado com sucesso";
            }
            catch (SqlException e)
            {
                this.mensagem = "Erro ao Logar no banco de dados";
            }
        }
    }
}
