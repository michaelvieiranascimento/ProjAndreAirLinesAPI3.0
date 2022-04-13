using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreAirLinesAPI3._0Models
{
    public class Passagem
    {
        public int Id { get; set; }
        public Voo Voo { get; set; }
        public Passageiro Passageiro { get; set; }
        public PrecoBase PrecoBase { get; set; }
        public Classe Classe { get; set; }
        public DateTime DataCadastro { get; set; }
        public Decimal ValorTotal { get; set; }
        public Decimal PromocaoPorcentagem { get; set; }
        public string LoginUser { get; set; }
    }
}
