using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniCRM.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }        
    }
}