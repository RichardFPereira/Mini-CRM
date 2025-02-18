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
        [Required(ErrorMessage = "A situação é obrigatória.",AllowEmptyStrings = false)]
        public string Status { get; set; }
    }
}