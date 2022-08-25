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
    public class EntregaMensagemService : IEntregaMensagemService
    {
        private readonly IEntregaRepository _repository;

        public EntregaMensagemService(IEntregaRepository repository)
        {
            _repository = repository;
        }
        public void EnviaMensagem(EntregaMensagem entrega)
        {
            _repository.EnviaMensagem(entrega);
        }
    }
}
