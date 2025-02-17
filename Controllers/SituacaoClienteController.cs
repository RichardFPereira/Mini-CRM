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
    public class SituacaoClienteController : ControllerBase
    {
        private readonly MiniCRMContext _context;

        public SituacaoClienteController (MiniCRMContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create (SituacaoCliente situacaoCliente)
        {
            _context.Add(situacaoCliente);
            _context.SaveChanges();
            return Ok(situacaoCliente);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterSituacaoPorId(int id)
        {
            var situacao = _context.SituacaoClientes.Find(id);

            if (situacao == null)
                return NotFound("ID de situacao inválido!");
                
            return Ok(situacao);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizarSituacao (int id, SituacaoCliente situacaoCliente)
        {
            var situacaoClienteBanco = _context.SituacaoClientes.Find(id);
            
            if (situacaoClienteBanco == null)
                return NotFound("ID de situacao inválido!");

            situacaoClienteBanco.Status = String.IsNullOrEmpty(situacaoCliente.Status) ? situacaoClienteBanco.Status : situacaoCliente.Status;
            _context.SituacaoClientes.Update(situacaoCliente);
            _context.SaveChanges();

            return Ok(situacaoClienteBanco);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarSituacao (int id)
        {
            var situacaoClienteBanco = _context.SituacaoClientes.Find (id);

            if (situacaoClienteBanco == null)
                return NotFound("ID de situacao inválido!");

            _context.SituacaoClientes.Remove(situacaoClienteBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}