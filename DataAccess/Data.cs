using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class Data : IData
    {
        string stringConexao;
        
        public Data()
        {
            this.stringConexao = "Server=localhost;Database=sac;Uid=root;Pwd=root;";
        }

        public bool AbrirTicket(string nomeDoUsuario, string email, string telefone, string mensagem)
        {
            using (MySqlConnection conexao = new MySqlConnection(this.stringConexao))
            {
                var resultado = conexao.Execute("INSERT INTO ticket (nome,email,telefone,mensagem) VALUES " +
                                                "(@nomeDeUsuario,@email,@telefone,@mensagem);", 
                                                new Ticket { nomeDeUsuario = nomeDoUsuario,
                                                             email = email,
                                                             telefone = telefone,
                                                             mensagem = mensagem
                                                });
                return resultado == 1;
            }
        }

        public IEnumerable<Ticket> GetTodosTickets()
        {
            using (MySqlConnection conexao = new MySqlConnection(this.stringConexao))
            {
                return conexao.Query<Ticket>("SELECT ticket_id ticketId, " +
                                             "nome nomeDeUsuario, " +
                                             "email email, " +
                                             "telefone telefone, " +
                                             "mensagem mensagem ," +
                                             "aberto aberto " +
                                             "FROM ticket;");
            }
        }

        public bool FecharTicket(int id)
        {
            using (MySqlConnection conexao = new MySqlConnection(this.stringConexao))
            {
                var resultado = conexao.Execute("UPDATE ticket SET aberto = '0' WHERE ticket_id = @id",new { id });
                return resultado == 1;
            }
        }

    }
}
