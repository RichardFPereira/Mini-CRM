using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCRM.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataCadastro { get; set; }
        
        public int? SituacaoClienteId { get; set; }
        public SituacaoCliente SituacaoCliente { get; set; }

        public List<Contato> Contatos { get; set; }
        public List<Endereco> Enderecos { get; set; }
    }
}