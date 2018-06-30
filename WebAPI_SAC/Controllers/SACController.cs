using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_SAC.Controllers
{
    public class SACController : Controller
    {
        IData dados;

        public SACController(IData dados)
        {
            this.dados = dados;
        }

        [Route("api/abrirTicket")]
        [HttpPost("{nomeDoUsuario}/{email}/{telefone}/{mensagem}")]
        public IActionResult AbrirTicket(string nomeDoUsuario, string email, string telefone, string mensagem)
        {
            try
            {
                return Ok(dados.AbrirTicket(nomeDoUsuario, email, email, mensagem));
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("api/getTodosTickets")]
        [HttpGet]
        public IActionResult GetTodosTickets()
        {
            try
            {
                return Ok(dados.GetTodosTickets());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("api/fecharTicket")]
        [HttpPost("{id}")]
        public IActionResult FecharTicket(int id)
        {
            try
            {
                return Ok(dados.FecharTicket(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}