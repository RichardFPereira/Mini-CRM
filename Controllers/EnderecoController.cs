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
            _context.Add(endereco);
            _context.SaveChanges();
            return Ok(endereco);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEnderecoById (int id)
        {
            var endereco = _context.Enderecos.Find(id);
            
            if (endereco == null)
                return NotFound();

            return Ok(endereco);
        }
    }
}