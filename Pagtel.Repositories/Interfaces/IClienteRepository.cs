using Pagtel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagtel.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        void EnviaMensagem(ClienteMensagem mensagem);

        void TrazCliente(ClienteMensagem mensagem);
    }
}
