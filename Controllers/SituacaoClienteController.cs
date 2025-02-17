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

        [HttpGet("{id}")]
        public IActionResult ObterSituacaoPorId(int id)
        {
            var situacao = _context.SituacaoClientes.Find(id);

            if (situacao == null)
                return NotFound();
                
            return Ok(situacao);
        }
    }
}