using Pagtel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagtel.Services.Interfaces
{
    public interface IProdutoMensagemService
    {
        void EnviaMensagem(ProdutoMensagem produto);
    }
}
