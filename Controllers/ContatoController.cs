using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            try
            {
                _context.Add(contato);
                _context.SaveChanges();

                return Ok(contato);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest("Ocorreu um conflito de concorrência ao salvar os dados.");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao salvar dados no banco.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno ao atualizar contato.");
            }
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

            try
            {
                _context.Contatos.Update(contatoBanco);
                _context.SaveChanges();

                return Ok(contatoBanco);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest("Ocorreu um conflito de concorrência ao salvar os dados.");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao salvar dados no banco.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno ao atualizar contato.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarContato (int id)
        {
            var contatoBanco = _context.Contatos.Find (id);

            if (contatoBanco == null)
                return NotFound("ID de contato inválido!");
            
            try
            {
                _context.Contatos.Remove(contatoBanco);
                _context.SaveChanges();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest("Ocorreu um conflito de concorrência ao salvar os dados.");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao salvar dados no banco.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno ao atualizar contato.");
            }
        }
    }
}