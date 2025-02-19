using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCRM.Context;
using MiniCRM.DTOs.ClienteDTOs;
using MiniCRM.DTOs.ContatoDTOs;
using MiniCRM.Entities;
using MiniCRM.Services;

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
        public IActionResult CreateContato (ContatoDTO contatoDTO)
        {
            if (_context.Clientes.Find(contatoDTO.ClienteId) == null)
                return NotFound("ID de cliente inválido!");            

            Contato contato = new Contato
            {
                ClienteId = contatoDTO.ClienteId,
                Nome = contatoDTO.Nome,
                Email = contatoDTO.Email,
                Telefone = contatoDTO.Telefone,
            };

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
        [Route("Todos")]
        public IActionResult GetContatos ()
        {
            var contatos = _context.Contatos.ToList();
            if (contatos == null)
                return NotFound("Não há contatos cadastrados na base.");

            List<ContatoReadDTO> contatosDTO = ContatoService.MapperContatoList(contatos);            
            return Ok(contatosDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetContatoById (int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
                return NotFound("ID de contato inválido!");            
            
            ContatoReadDTO contatoReadDTO = new ContatoReadDTO
            {
                Id = contato.Id,
                ClienteId = contato.ClienteId,
                Nome = contato.Nome,
                Email = contato.Email,
                Telefone = contato.Telefone,
            };

            return Ok(contatoReadDTO);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateContato (int id, ContatoDTO contatoDTO)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
                return NotFound("ID de contato inválido!");

            if (_context.Clientes.Find(contato.ClienteId) == null)
                return NotFound("ID de cliente inválido!");
            
            contato.ClienteId = contatoDTO.ClienteId;
            contato.Nome = contatoDTO.Nome;
            contato.Email = contatoDTO.Email;
            contato.Telefone = contatoDTO.Telefone;

            try
            {
                _context.Contatos.Update(contato);
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

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteContato (int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return NotFound("ID de contato inválido!");
            
            try
            {
                _context.Contatos.Remove(contato);
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