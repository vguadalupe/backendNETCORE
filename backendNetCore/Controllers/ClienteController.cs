using backendNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace backendNetCore.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase

    {
        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente()
        {
            //

            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    id= "1",
                    nombre="Cris",
                    correo="cris@test.com",
                    edad="38"
                },

                new Cliente
                {
                    id= "2",
                    nombre="Adrian",
                    correo="adrian@test.com",
                    edad="36"
                },

                new Cliente
                {
                    id= "3",
                    nombre="andres",
                    correo="andres@test.com",
                    edad="28"
                }

            };
            return clientes;
        } //enlistarClientes


        [HttpGet]
        [Route("listarxid")]
        public dynamic listarClienteId(string id)
        {
            //

            List<Cliente> clientes = new List<Cliente>
    {
        new Cliente
        {
            id = "1",
            nombre = "Cris",
            correo = "cris@test.com",
            edad = "38"
        },
        new Cliente
        {
            id = "2",
            nombre = "John",
            correo = "john@test.com",
            edad = "42"
        },
        new Cliente
        {
            id = "3",
            nombre = "Andy",
            correo = "andy@test.com",
            edad = "24"
        },
        
    };

            // Buscar el cliente por su ID
            Cliente clienteEncontrado = clientes.FirstOrDefault(c => c.id == id);

            return clienteEncontrado;
        } //enlistarClientesID



        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Cliente cliente)
        {
            cliente.id = "4";

            return new
            {
                success = true,
                message = "cliente registrado",
                result = cliente
            };

        }

        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarCliente(Cliente cliente)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            if (token == "test123")
            {
                return new
                {
                    success = true,
                    message = "cliente eliminado",
                    result = cliente
                };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "token invalido"
                    
                };
            }
        }
    }
}
