using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MiniCRM.Entities
{
    public class Endereco
    {
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [JsonIgnore]
        public Cliente Cliente { get; set; }

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
}