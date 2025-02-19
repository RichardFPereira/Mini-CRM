using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniCRM.DTOs.EnderecoDTOs;
using MiniCRM.Entities;

namespace MiniCRM.Services
{
    public class EnderecoService
    {
        public static List<EnderecoReadDTO> MapperEnderecosList (List<Endereco> enderecos)
        {
            List<EnderecoReadDTO> enderecosDTO = new List<EnderecoReadDTO>();
            foreach (Endereco endereco in enderecos)
            {
                EnderecoReadDTO enderecoDTO = new EnderecoReadDTO()
                {
                    Id = endereco.Id,
                    ClienteId = endereco.ClienteId,
                    CEP = endereco.CEP,
                    Logradouro = endereco.Logradouro,
                    Numero = endereco.Numero,
                    Complemento = endereco.Complemento,
                    Bairro = endereco.Bairro,
                    Cidade = endereco.Cidade,
                    Estado = endereco.Estado
                };

                enderecosDTO.Add(enderecoDTO);
            }

            return enderecosDTO;
        }
    }
}