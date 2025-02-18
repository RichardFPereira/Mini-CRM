using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MiniCRM.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; }
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
}