using APIclientes.Database.Models;
using APIclientes.Services.DTOs;
using System;

namespace APIclientes.Services.Parses
{
    public class ClienteParser
    {
        public static TbCliente ToTbCliente(
            CriarClienteDTO novoCliente)
        {
            TbCliente Response = new(); 
            Response.Nome = novoCliente.Nome;
            Response.Criadoem = DateTime.Now.ToUniversalTime();
            Response.Alteradoem = Response.Criadoem;
            Response.Telefone = novoCliente.Telefone;
            Response.Documento = novoCliente.Documento;
            Response.Nascimento = novoCliente.Nascimento;
            Response.Tipodoc = novoCliente.Tipodoc;

            return Response;
        }

        public static ClienteDTO ToClienteDTO(
            TbCliente cliente)
        {
            ClienteDTO Response = new();
            Response.Id = cliente.Id;
            Response.Nome = cliente.Nome;
            Response.Criadoem = cliente.Criadoem;
            Response.Alteradoem = cliente.Alteradoem;
            Response.Telefone = cliente.Telefone;
            Response.Documento = cliente.Documento;
            Response.Nascimento = cliente.Nascimento;
            Response.Tipodoc = cliente.Tipodoc;

            return Response;
        }

    }
}
