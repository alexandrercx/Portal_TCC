using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoAssociadoWeb.Models
{
    public class AgendamentoViewModel
    {
        public int Id { get; set; }
        public TipoAtendimentoViewModel TipoAtendimento { get; set; }
        public AssociadoViewModel Associado { get; set; }
        public ConveniadoViewModel Conveniado { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public DateTime DatHoraAtendimento { get; set; }
        public DateTime? DataAgendamento { get; set; }

    }
}
