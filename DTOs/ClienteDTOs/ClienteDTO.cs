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
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [StringLength(14, ErrorMessage = "CNPJ deve ter até 14 caracteres (somente dígitos).")]
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