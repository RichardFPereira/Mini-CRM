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
    public class EnderecoController : ControllerBase
    {
        private readonly MiniCRMContext _context;

        public EnderecoController (MiniCRMContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create (Endereco endereco)
        {
            try
            {
                _context.Add(endereco);
                _context.SaveChanges();

                return Ok(endereco);
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
                return StatusCode(500, "Erro interno ao atualizar endereco.");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEnderecoById (int id)
        {
            var endereco = _context.Enderecos.Find(id);
            
            if (endereco == null)
                return NotFound("ID de endereço inválido!");

            return Ok(endereco);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizaEndereco (int id, Endereco endereco)
        {
            var enderecoBanco = _context.Enderecos.Find(id);
            if (enderecoBanco == null)
                return NotFound("ID de endereço inválido!");

            if (_context.Clientes.Find(endereco.ClienteId) == null)
                return NotFound("ID de cliente inválido!");

            enderecoBanco.ClienteId = endereco.ClienteId;
            enderecoBanco.CEP = String.IsNullOrEmpty(endereco.CEP) 
                ? enderecoBanco.CEP 
                : endereco.CEP;
            enderecoBanco.Logradouro = String.IsNullOrEmpty(endereco.Logradouro) 
                ? enderecoBanco.Logradouro 
                : endereco.Logradouro;
            enderecoBanco.Numero = String.IsNullOrEmpty(endereco.Numero) 
                ? enderecoBanco.Numero 
                : endereco.Numero;
            enderecoBanco.Complemento = String.IsNullOrEmpty(endereco.Complemento) 
                ? enderecoBanco.Complemento 
                : endereco.Complemento;
            enderecoBanco.Bairro = String.IsNullOrEmpty(endereco.Bairro) 
                ? enderecoBanco.Bairro 
                : endereco.Bairro;
            enderecoBanco.Cidade = String.IsNullOrEmpty(endereco.Cidade) 
                ? enderecoBanco.Cidade 
                : endereco.Cidade;
            enderecoBanco.Estado = String.IsNullOrEmpty(endereco.Estado) 
                ? enderecoBanco.Estado 
                : endereco.Estado;

            try
            {
                _context.Enderecos.Update(enderecoBanco);
                _context.SaveChanges();

                return Ok(enderecoBanco);
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
                return StatusCode(500, "Erro interno ao atualizar endereço.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarEndereco (int id)
        {
            var enderecoBanco = _context.Enderecos.Find (id);

            if (enderecoBanco == null)
                return NotFound("ID de endereço Inválido!");
            
            try
            {
                _context.Enderecos.Remove(enderecoBanco);
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
                return StatusCode(500, "Erro interno ao atualizar endereco.");
            }
        }
    }
}