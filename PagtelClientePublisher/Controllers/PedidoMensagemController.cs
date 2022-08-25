using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagtel.Models.Entities;
using Pagtel.Services.Interfaces;

namespace PagtelClientePublisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoMensagemController : ControllerBase
    {
        private readonly IPedidoMensagemService _service;

        public PedidoMensagemController(IPedidoMensagemService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddMensagem(PedidoMensagem pedido)
        {
            _service.EnviaMensagem(pedido);
        }
    }
}

