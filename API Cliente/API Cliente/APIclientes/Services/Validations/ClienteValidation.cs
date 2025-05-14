using APIclientes.Services.DTOs;
using APIclientes.Services.Exceptions;
using System.Linq;

namespace APIclientes.Services.Validations
{
    public class ClienteValidation
    {
        public static void ValidouCriarCliente(
            CriarClienteDTO criarClienteDTO)
        {
            if (string.IsNullOrEmpty(criarClienteDTO.Nome))
                throw new BadRequestException("Nome é obrigatorio");

            if (string.IsNullOrEmpty (criarClienteDTO.Documento))
                throw new BadRequestException("Documento é obrigatorio");

            if (!new[] { 0, 1, 2, 3, 99 }.Contains(
                criarClienteDTO.Tipodoc))
                    throw new BadRequestException("Documento é obrigatorio");

        }
    }
}
