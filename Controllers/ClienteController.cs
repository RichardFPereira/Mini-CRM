using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCRM.Context;
using MiniCRM.DTOs.ClienteDTOs;
using MiniCRM.DTOs.ContatoDTOs;
using MiniCRM.DTOs.EnderecoDTOs;
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
        public IActionResult CreateCliente(ClienteDTO  clienteDTO)
        {   
            var cliente = new Cliente
            {
                Nome = clienteDTO.Nome,
                CNPJ = clienteDTO.CNPJ,
                DataCadastro = DateTime.Now,
                SituacaoClienteId = clienteDTO.SituacaoClienteId,
            };

            try
            {
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
        [Route("Todos")]
        public IActionResult GetClientes()
        {
            var clientes = _context.Clientes.ToList();
            if (clientes == null)
                return NotFound("Não há clientes cadastrados na base");
            
            List<ClienteReadDTO> clientesDTO = new List<ClienteReadDTO>();
            foreach (Cliente cliente in clientes)
            {
                var enderecos = _context.Enderecos.Where(x => x.ClienteId == cliente.Id).ToList();
                List<EnderecoReadDTO> enderecosDTO = new List<EnderecoReadDTO>();

                foreach (Endereco endereco in enderecos)
                {
                    EnderecoReadDTO enderecoDTO = new EnderecoReadDTO()
                    {
                        Id = endereco.Id,
                        ClienteId = endereco.ClienteId,
                        CEP = endereco.CEP,
                        Logradouro = endereco.Logradouro,
                        Numero = endereco.Numero,
                        Complemento = endereco.Complemento,
                        Bairro = endereco.Bairro,
                        Cidade = endereco.Cidade,
                        Estado = endereco.Estado
                    };
                    
                    enderecosDTO.Add(enderecoDTO);
                }

                var contatos = _context.Contatos.Where(x => x.ClienteId == cliente.Id).ToList();
                List<ContatoReadDTO> contatosDTO = new List<ContatoReadDTO>();

                foreach (Contato contato in contatos)
                {
                    ContatoReadDTO contatoDTO = new ContatoReadDTO()
                    {
                        Id = contato.Id,
                        ClienteId = contato.ClienteId,
                        Nome = contato.Nome,
                        Email = contato.Email,
                        Telefone = contato.Telefone
                    };
                    
                    contatosDTO.Add(contatoDTO);
                }

                var situacaoCliente = _context.SituacaoClientes.Find(cliente.SituacaoClienteId);
                ClienteReadDTO clienteDTO = new ClienteReadDTO
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    CNPJ = cliente.CNPJ,
                    SituacaoClienteId = cliente.SituacaoClienteId,
                    SituacaoStatus = situacaoCliente.Status,
                    Enderecos = enderecosDTO,
                    Contatos = contatosDTO
                };

                clientesDTO.Add(clienteDTO);
            }

            return Ok(clientesDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetClienteById (int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
                return NotFound("ID de cliente inválido!");

            var enderecos = _context.Enderecos.Where(x => x.ClienteId == cliente.Id).ToList();
                List<EnderecoReadDTO> enderecosDTO = new List<EnderecoReadDTO>();

                foreach (Endereco endereco in enderecos)
                {
                    EnderecoReadDTO enderecoDTO = new EnderecoReadDTO()
                    {
                        Id = endereco.Id,
                        ClienteId = endereco.ClienteId,
                        CEP = endereco.CEP,
                        Logradouro = endereco.Logradouro,
                        Numero = endereco.Numero,
                        Complemento = endereco.Complemento,
                        Bairro = endereco.Bairro,
                        Cidade = endereco.Cidade,
                        Estado = endereco.Estado
                    };
                    
                    enderecosDTO.Add(enderecoDTO);
                }

                var contatos = _context.Contatos.Where(x => x.ClienteId == cliente.Id).ToList();
                List<ContatoReadDTO> contatosDTO = new List<ContatoReadDTO>();

                foreach (Contato contato in contatos)
                {
                    ContatoReadDTO contatoDTO = new ContatoReadDTO()
                    {
                        Id = contato.Id,
                        ClienteId = contato.ClienteId,
                        Nome = contato.Nome,
                        Email = contato.Email,
                        Telefone = contato.Telefone
                    };
                    
                    contatosDTO.Add(contatoDTO);
                }

            var situacaoCliente = _context.SituacaoClientes.Find(cliente.SituacaoClienteId);
            var clienteReadDTO = new ClienteReadDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                CNPJ = cliente.CNPJ,
                DataCadastro = cliente.DataCadastro,
                SituacaoClienteId = cliente.SituacaoClienteId,
                SituacaoStatus = situacaoCliente.Status,
                Contatos = contatosDTO,
                Enderecos = enderecosDTO
            };

            return Ok(clienteReadDTO);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateCliente (int id, ClienteDTO  clienteDTO)
        {
            var cliente = _context.Clientes.Find(id);            
            if (cliente == null)
                return NotFound("ID de cliente inválido!");
            
            cliente.Nome = clienteDTO.Nome;
            cliente.CNPJ = clienteDTO.CNPJ;
            cliente.SituacaoClienteId = clienteDTO.SituacaoClienteId;
            
            try
            {
                _context.Clientes.Update(cliente);
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

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCliente (int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
                return NotFound("ID de cliente inválido!");

            try
            {
                _context.Clientes.Remove(cliente);
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