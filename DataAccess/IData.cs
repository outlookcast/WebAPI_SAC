using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IData
    {
        bool AbrirTicket(string nomeDoUsuario, string email, string telefone, string mensagem);
        IEnumerable<Ticket> GetTodosTickets();
        bool FecharTicket(int id);
    }
}
