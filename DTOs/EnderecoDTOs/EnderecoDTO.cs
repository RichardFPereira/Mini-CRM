using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCRM.DTOs.EnderecoDTOs
{
    public class EnderecoDTO
    {
        [Required]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.",AllowEmptyStrings = false)]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP inválido. Formato esperado: 00000-000")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O logradouro é obrigatório.",AllowEmptyStrings = false)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O número é obrigatório.",AllowEmptyStrings = false)]
        [StringLength(5, ErrorMessage = "Número muito longo (máximo 5 caracteres).")]        
        public string Numero { get; set; }

        [Required(ErrorMessage = "O complemento é obrigatório.",AllowEmptyStrings = false)]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório.",AllowEmptyStrings = false)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.",AllowEmptyStrings = false)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório.",AllowEmptyStrings = false)]
        [StringLength(2, ErrorMessage = "Estado deve ter 2 caracteres (ex: SP, RJ, MG).")]
        public string Estado { get; set; }
    }

    public class EnderecoReadDTO
    {
        public int ClienteId { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}