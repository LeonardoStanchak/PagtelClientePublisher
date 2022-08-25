using Pagtel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagtel.Repositories.Interfaces
{
    public interface IProdutosRepository
    {
        void EnviaMensagem(ProdutoMensagem produto);
    }
}
