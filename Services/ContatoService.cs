using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniCRM.DTOs.ContatoDTOs;
using MiniCRM.Entities;

namespace MiniCRM.Services
{
    public class ContatoService
    {
        public static List<ContatoReadDTO> MapperContatoList (List<Contato> contatos)
        {
            List<ContatoReadDTO> contatosDTO = new List<ContatoReadDTO>();
            foreach (Contato contato in contatos)
            {
                ContatoReadDTO contatoDTO = new ContatoReadDTO()
                {
                    Id = contato.Id,
                    ClienteId = contato.ClienteId,
                    Nome = contato.Nome,
                    Email = contato.Email,
                    Telefone = contato.Telefone
                };                
                contatosDTO.Add(contatoDTO);
            }

            return contatosDTO;
        }
    }
}