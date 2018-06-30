using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Ticket
    {
        public int ticketId { get; set; }
        public string nomeDeUsuario { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string mensagem { get; set; }
        public bool aberto { get; set; }
    }
}
