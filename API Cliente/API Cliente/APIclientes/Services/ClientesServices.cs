using System;
using System.Linq;
﻿using APIclientes.Database.Models;
using APIclientes.Services.DTOs;
using APIclientes.Services.Parses;
using APIclientes.Services.Validations;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace APIclientes.Services
{
    public class ClientesService
    {
        private readonly ApiclienteContext _dbcontext;
        public ClientesService(ApiclienteContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public ClienteDTO Criar(CriarClienteDTO dto)
        {
            ClienteValidation.ValidouCriarCliente(dto);

            TbCliente novoCliente = ClienteParser.ToTbCliente(dto); 

            _dbcontext.TbClientes.Add(novoCliente);
            _dbcontext.SaveChanges();

            return ClienteParser.ToClienteDTO(novoCliente);
        }

        public void Deletar(int id)
        {
            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            _dbcontext.TbClientes.Remove(cliente);
            _dbcontext.SaveChanges();
        }


        public List<ClienteDTO> Listar()
        {
            var clientes = _dbcontext.TbClientes.ToList();
            return clientes.Select(ClienteParser.ToClienteDTO).ToList();
        }


        public ClienteDTO BuscarPorId(int id)
        {
            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            return ClienteParser.ToClienteDTO(cliente);
        }


        public ClienteDTO Atualizar(int id, CriarClienteDTO dto)
        {
            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            cliente.Nome = dto.Nome;
            cliente.Documento = dto.Documento;
            cliente.Telefone = dto.Telefone;
            cliente.Nascimento = dto.Nascimento;
            cliente.Tipodoc = dto.Tipodoc;

            _dbcontext.SaveChanges();

            return ClienteParser.ToClienteDTO(cliente);
        }

    }
}
