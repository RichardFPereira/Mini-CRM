using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniCRM.Context;
using MiniCRM.Entities;

namespace MiniCRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly MiniCRMContext _context;

        public ContatoController (MiniCRMContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create (Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetContatoById (int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return NotFound("ID de contato inválido!");

            return Ok(contato);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizaContato (int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);
            if (contatoBanco == null)
                return NotFound("ID de contato inválido!");

            if (_context.Clientes.Find(contato.ClienteId) == null)
                return NotFound("ID de cliente inválido!");
            
            contatoBanco.ClienteId = contato.ClienteId;
            contatoBanco.Nome = String.IsNullOrEmpty(contatoBanco.Nome) ? contatoBanco.Nome : contatoBanco.Nome;
            contatoBanco.Telefone = String.IsNullOrEmpty(contatoBanco.Telefone) ? contatoBanco.Telefone : contatoBanco.Telefone;
            contatoBanco.Email = String.IsNullOrEmpty(contatoBanco.Email) ? contatoBanco.Email : contatoBanco.Email;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarContato (int id)
        {
            var contatoBanco = _context.Contatos.Find (id);

            if (contatoBanco == null)
                return NotFound("ID de contato inválido!");

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}