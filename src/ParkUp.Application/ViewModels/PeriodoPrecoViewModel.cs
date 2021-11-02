﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ParkUp.Application.ViewModels
{
    public class PeriodoPrecoViewModel
    {
        public int Id { get; set; }
        public int IdTipoPreco { get; set; }
        public int Periodo { get; set; }
        public decimal Valor { get; set; }
        public int TempoToleranciaSaida { get; set; }        
        public decimal ValorHoraAdicional { get; set; }
    
    }
}