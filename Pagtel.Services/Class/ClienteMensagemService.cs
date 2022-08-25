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
    public class ClienteMensagemService : IClienteMensagemService
    {
        private readonly IClienteRepository _repository;

        public ClienteMensagemService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public void EnviaMensagem(ClienteMensagem mensagem)
        {
            _repository.EnviaMensagem(mensagem);
        }

        public void TrazCLiente(ClienteMensagem mensagem)
        {
            _repository.TrazCliente(mensagem);
        }
    }
}
