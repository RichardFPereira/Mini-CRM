using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MiniCRM.DTOs.ContatoDTOs;
using MiniCRM.DTOs.EnderecoDTOs;

namespace MiniCRM.DTOs.ClienteDTOs
{
    public class ClienteDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "CNPJ deve ter 14 caracteres (somente dígitos).")]
        public string CNPJ { get; set; }

        [Required]
        public int? SituacaoClienteId { get; set; }  
    }

    public class ClienteReadDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataCadastro { get; set; }

        public int? SituacaoClienteId { get; set; }
        public string SituacaoStatus { get; set; }

        public List<ContatoReadDTO> Contatos { get; set; }
        public List<EnderecoReadDTO> Enderecos { get; set; }
    }
}