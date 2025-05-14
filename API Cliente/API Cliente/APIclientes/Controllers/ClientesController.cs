using APIclientes.Database.Models;
using APIclientes.Services;
using APIclientes.Services.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace APIclientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly ClientesService _service;
        public ClientesController(ClientesService service)
        {
            _service = service;
        }


        [HttpPost]
        public ActionResult<ClienteDTO> 
            Adicionar([FromBody] CriarClienteDTO body)
        {
            try
            {
                var Response = _service.Criar(body);
                return Ok(Response); // 200
            }
            catch (BadHttpRequestException B)
            {
                return BadRequest(B.Message);   // 400
            }
            catch (System.Exception E)
            {
                return StatusCode(500, E.Message); // 500
            } 
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            try
            {
                _service.Deletar(id);
                return NoContent(); // 204
            }
            catch (Exception e)
            {
                return NotFound(e.Message); // 404
            }
        }


        [HttpGet]
        public ActionResult<List<ClienteDTO>> Listar()
        {
            var resultado = _service.Listar();
            return Ok(resultado);
        }


        [HttpGet("{id}")]
        public ActionResult<ClienteDTO> BuscarPorId(int id)
        {
            try
            {
                var cliente = _service.BuscarPorId(id);
                return Ok(cliente);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpPut("{id}")]
        public ActionResult<ClienteDTO> Atualizar(int id, [FromBody] CriarClienteDTO body)
        {
            try
            {
                var cliente = _service.Atualizar(id, body);
                return Ok(cliente);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
