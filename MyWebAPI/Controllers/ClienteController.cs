using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Controllers
{
    [ApiController]
    //Rota atualizada para um nome
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private static readonly List<ClienteDTO> Clientes = new List<ClienteDTO>
        {
            new ClienteDTO { Id = 1, Nome = "João", Telefone = "123456789", Endereco = "Rua A" },
            new ClienteDTO { Id = 2, Nome = "Maria", Telefone = "987654321", Endereco = "Rua B" },
            new ClienteDTO { Id = 3, Nome = "Paulo", Telefone = "000000000", Endereco = "Rua C" }

        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Clientes);
        }

        [HttpGet("{id}", Name = "GetCliente")]
        public IActionResult GetById(int id)
        {
            var cliente = Clientes.Find(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Create(ClienteDTO cliente)
        {
            
            cliente.Id = Clientes.Count + 1;
            Clientes.Add(cliente);

            return CreatedAtRoute("GetCliente", new { id = cliente.Id }, cliente);
        }
    }
}
