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
    public class ClienteController : ControllerBase
    {
        private readonly MiniCRMContext _context;
        public ClienteController (MiniCRMContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {            
            try
            {
                cliente.DataCadastro = DateTime.Now;
                _context.Add(cliente);
                _context.SaveChanges();
                
                return Ok(cliente);
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
                return StatusCode(500, "Erro interno ao atualizar cliente.");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetClienteById (int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
                return NotFound("ID de cliente inválido!");

            return Ok(cliente);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizarCliente (int id, Cliente cliente)
        {
            var clienteBanco = _context.Clientes.Find(id);            
            if (clienteBanco == null)
                return NotFound("ID de cliente inválido!");
            
            clienteBanco.Nome = String.IsNullOrEmpty(cliente.Nome) ? clienteBanco.Nome : cliente.Nome;
            clienteBanco.CNPJ = String.IsNullOrEmpty(cliente.CNPJ) ? clienteBanco.CNPJ : cliente.CNPJ;
            clienteBanco.SituacaoCliente = (_context.SituacaoClientes.Find(cliente.SituacaoCliente) == null) ? clienteBanco.SituacaoCliente : cliente.SituacaoCliente;

            try
            {
                _context.Clientes.Update(clienteBanco);
                _context.SaveChanges();
            
                return Ok(clienteBanco);
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
                return StatusCode(500, "Erro interno ao atualizar cliente.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarCliente (int id)
        {
            var clienteBanco = _context.Clientes.Find (id);

            if (clienteBanco == null)
                return NotFound("ID de cliente inválido!");

            try
            {
                _context.Clientes.Remove(clienteBanco);
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
                return StatusCode(500, "Erro interno ao atualizar cliente.");
            }
        }
    }
}