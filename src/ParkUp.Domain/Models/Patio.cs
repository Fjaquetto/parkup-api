using System;
using System.Collections.Generic;
using System.Text;

namespace ParkUp.Domain.Models
{
    public class Patio
    {
        public int ID_PATIO { get; set; }

        public int ID_EMPRESA { get; set; }

        public string PLACA { get; set; }

        public int ID_MODELO { get; set; }

        public int ID_COR { get; set; }

        public DateTime DATA_HORA_ENTRADA { get; set; }

        public DateTime DATA_HORA_SAIDA { get; set; }

        public string PERMANENCIA { get; set; }

        public decimal VALOR { get; set; }

        public int ID_TIPO_AVULSO { get; set; }

        public int ID_FECHAMENTO_GERAL { get; set; }
    }
}
