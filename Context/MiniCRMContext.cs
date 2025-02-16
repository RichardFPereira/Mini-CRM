using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniCRM.Entities;

namespace MiniCRM.Context
{
    public class MiniCRMContext : DbContext
    {
        public MiniCRMContext(DbContextOptions<MiniCRMContext> options) : base (options)
        {

        }

        public DbSet<SituacaoCliente> SituacaoClientes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Contato> Contatos { get; set; }        
    }
}