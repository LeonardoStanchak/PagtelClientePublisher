using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagtel.Models.Entities;
using Pagtel.Services.Interfaces;

namespace PagtelClientePublisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregaMensagemController : ControllerBase
    {
        private readonly IEntregaMensagemService _service;

        public EntregaMensagemController(IEntregaMensagemService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddNovaEntrega (EntregaMensagem entrega)
        {
            _service.EnviaMensagem(entrega);
        }
    }
}
