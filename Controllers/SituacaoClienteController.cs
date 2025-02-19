using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCRM.Context;
using MiniCRM.DTOs.SituacaoClienteDTOs;
using MiniCRM.Entities;

namespace MiniCRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SituacaoClienteController : ControllerBase
    {
        private readonly MiniCRMContext _context;

        public SituacaoClienteController (MiniCRMContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateSituacaoCliente (SituacaoClienteDTO situacaoClienteDTO)
        {
            SituacaoCliente situacaoCliente = new SituacaoCliente
            {
                Status = situacaoClienteDTO.Status
            };

            try
            {
                _context.Add(situacaoCliente);
                _context.SaveChanges();
                return Ok(situacaoCliente);
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
                return StatusCode(500, "Erro interno ao atualizar situacao.");
            }     
        }

        [HttpGet]
        [Route("Todos")]
        public IActionResult GetSituacoes()
        {
            var situacoes = _context.SituacaoClientes.ToList();
            if (situacoes == null)
                return NotFound("Não há situações cadastradas na base.");
            
            List<SituacaoClienteReadDTO> situacoesClientesDTO = new List<SituacaoClienteReadDTO>();
            foreach (SituacaoCliente situacaoCliente in situacoes)
            {
                SituacaoClienteReadDTO situacaoClienteDTO = new SituacaoClienteReadDTO
                {
                    Id = situacaoCliente.Id,
                    Status = situacaoCliente.Status
                };

                situacoesClientesDTO.Add(situacaoClienteDTO);
            }

            return Ok(situacoesClientesDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSituacaoClienteById(int id)
        {
            var situacao = _context.SituacaoClientes.Find(id);
            if (situacao == null)
                return NotFound("ID de situacao inválido!");

            SituacaoClienteReadDTO situacaoClienteDTO = new SituacaoClienteReadDTO
            {
                Id = situacao.Id,
                Status = situacao.Status
            };
                
            return Ok(situacaoClienteDTO);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateSituacaoCliente (int id, SituacaoClienteDTO situacaoClienteDTO)
        {
            var situacaoCliente = _context.SituacaoClientes.Find(id);            
            if (situacaoCliente == null)
                return NotFound("ID de situacao inválido!");

            situacaoCliente.Status = situacaoClienteDTO.Status;

            try
            {                
                _context.SituacaoClientes.Update(situacaoCliente);
                _context.SaveChanges();

                return Ok(situacaoCliente);
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
                return StatusCode(500, "Erro interno ao atualizar situacao.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteSituacaoCliente (int id)
        {
            var situacaoCliente = _context.SituacaoClientes.Find (id);

            if (situacaoCliente == null)
                return NotFound("ID de situacao inválido!");

            try
            {
                _context.SituacaoClientes.Remove(situacaoCliente);
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
                return StatusCode(500, "Erro interno ao atualizar situacao.");
            }
        }
    }
}