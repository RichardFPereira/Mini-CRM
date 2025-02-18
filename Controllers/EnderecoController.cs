using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCRM.Context;
using MiniCRM.DTOs.ClienteDTOs;
using MiniCRM.DTOs.EnderecoDTOs;
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
        public IActionResult CreateEndereco(EnderecoDTO enderecoDTO)
        {

            if(_context.Clientes.Find(enderecoDTO.ClienteId) == null)
                return NotFound("ID de cliente inválido!");            
            
            Endereco endereco = new Endereco
            {
                ClienteId = enderecoDTO.ClienteId,
                CEP = enderecoDTO.CEP,
                Logradouro = enderecoDTO.Logradouro,
                Numero = enderecoDTO.Numero,
                Complemento = enderecoDTO.Complemento,
                Bairro = enderecoDTO.Bairro,
                Cidade = enderecoDTO.Cidade,
                Estado = enderecoDTO.Estado
            };

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

            EnderecoReadDTO enderecoDTO = new EnderecoReadDTO
            {
                ClienteId = endereco.ClienteId,
                CEP = endereco.CEP,
                Logradouro = endereco.Logradouro,
                Numero = endereco.Numero,
                Complemento = endereco.Complemento,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado
            };

            return Ok(enderecoDTO);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateEndereco (int id, EnderecoDTO enderecoDTO)
        {
            var endereco = _context.Enderecos.Find(id);
            if (endereco == null)
                return NotFound("ID de endereço inválido!");

            if (_context.Clientes.Find(endereco.ClienteId) == null)
                return NotFound("ID de cliente inválido!");

            endereco.ClienteId = enderecoDTO.ClienteId;
            endereco.CEP = enderecoDTO.CEP;
            endereco.Logradouro = enderecoDTO.Logradouro;
            endereco.Numero = enderecoDTO.Numero;
            endereco.Bairro = enderecoDTO.Bairro;
            endereco.Cidade = enderecoDTO.Cidade;
            endereco.Estado = enderecoDTO.Estado;

            try
            {
                _context.Enderecos.Update(endereco);
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
                return StatusCode(500, "Erro interno ao atualizar endereço.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEndereco (int id)
        {
            var endereco = _context.Enderecos.Find (id);

            if (endereco == null)
                return NotFound("ID de endereço Inválido!");
            
            try
            {
                _context.Enderecos.Remove(endereco);
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