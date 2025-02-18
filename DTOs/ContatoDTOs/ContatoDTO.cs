using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MiniCRM.DTOs.ClienteDTOs;

namespace MiniCRM.DTOs.ContatoDTOs
{
    public class ContatoDTO
    {
        [Required]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.",AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.",AllowEmptyStrings = false)]
        [Phone]
        public string Telefone { get; set; }
        
        [Required(ErrorMessage = "O e-mail é obrigatório.",AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class ContatoReadDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}