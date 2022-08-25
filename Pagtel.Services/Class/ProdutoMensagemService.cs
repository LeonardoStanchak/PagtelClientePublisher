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
    public class ProdutoMensagemService : IProdutoMensagemService
    {
        private readonly IProdutosRepository _repository;

        public ProdutoMensagemService(IProdutosRepository repository)
        {
            _repository = repository;
        }
        public void EnviaMensagem(ProdutoMensagem produto)
        {
            _repository.EnviaMensagem(produto);
        }
    }
}
