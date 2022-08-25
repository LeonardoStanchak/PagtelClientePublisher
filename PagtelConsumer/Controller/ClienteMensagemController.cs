using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagtel.Models.Entities;
using Pagtel.Services.Interfaces;

namespace PagtelClientePublisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteMensagemController : ControllerBase 
    {
        private IClienteMensagemService _service;

        public ClienteMensagemController(IClienteMensagemService service)
        {
            _service = service;
        }

        [HttpGet]
        public void TrazCliente(ClienteMensagem mensagem)
        {
            _service.TrazCLiente(mensagem);
        }
    }
}
