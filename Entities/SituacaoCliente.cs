using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCRM.Entities
{
    public class SituacaoCliente
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}