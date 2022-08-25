using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagtel.Models.Entities
{
    public class EntregaMensagem
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public string DataEntrega { get; set; }

        public int PedidoID { get; set; }
    }
}
