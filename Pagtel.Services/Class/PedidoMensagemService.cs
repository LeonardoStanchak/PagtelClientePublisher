using Pagtel.Models.Entities;
using Pagtel.Repositories.Interfaces;
using Pagtel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagtel.Services.Class
{
    public class PedidoMensagemService : IPedidoMensagemService
    {
        private readonly IPedidoRepository _repository;

        public PedidoMensagemService(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public void EnviaMensagem(PedidoMensagem pedido)
        {
            _repository.EnviaMensagem(pedido);
        }
    }
}
