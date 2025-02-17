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
            cliente.DataCadastro = DateTime.Now;
            _context.Add(cliente);
            _context.SaveChanges();
            return Ok(cliente);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetClienteById (int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }
    }
}