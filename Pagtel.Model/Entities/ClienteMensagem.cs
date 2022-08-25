using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagtel.Models.Entities
{
    public class ClienteMensagem
    {

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string DataNascimento { get; set; }

        public string Cep { get; set; }

        public string Endereco { get; set; }

        public string Complemento { get; set; }

        public string NumeroEndereco { get; set; }

        public string Referencia { get; set; }

    }
}
