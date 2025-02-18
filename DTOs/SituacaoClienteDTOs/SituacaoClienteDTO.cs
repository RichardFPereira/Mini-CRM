using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCRM.DTOs.SituacaoClienteDTOs
{
    public class SituacaoClienteDTO
    {
        [Required(ErrorMessage = "A situação é obrigatória.",AllowEmptyStrings = false)]
        public string Status { get; set; }
    }

    public class SituacaoClienteReadDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }

}