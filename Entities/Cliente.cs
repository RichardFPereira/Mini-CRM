using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MiniCRM.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.",AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O CNPJ é obrigatório.",AllowEmptyStrings = false)]
        [StringLength(14)]
        public string CNPJ { get; set; }
        public DateTime DataCadastro { get; set; }        
        public int? SituacaoClienteId { get; set; }
        [JsonIgnore]
        public SituacaoCliente SituacaoCliente { get; set; }
    }
}