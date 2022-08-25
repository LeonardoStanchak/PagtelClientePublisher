using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagtel.Models.Entities
{
    public class PedidoMensagem
    {

        public string DataPedido { get; set; }

        public string NumeroPedido { get; set; }

        public int ClienteID { get; set; }

        public int ProdutoId { get; set; }


    }
}
