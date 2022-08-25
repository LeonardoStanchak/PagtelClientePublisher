using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagtel.Models.Entities;
using Pagtel.Services.Interfaces;

namespace PagtelClientePublisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoMensagemController : ControllerBase
    {
        private readonly IProdutoMensagemService _service;

        public ProdutoMensagemController(IProdutoMensagemService service)
        {
        _service = service;
        }

        [HttpPost]
        public void AddMensagem (ProdutoMensagem produto)
        {
            _service.EnviaMensagem(produto);
        }
    }
}
