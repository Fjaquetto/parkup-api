﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkUp.Application.Interfaces;
using ParkUp.Application.ViewModels;
using ParkUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkUp.Services.Api.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/tipo-precos")]
    public class TipoPrecosController : ApiController
    {
        private readonly ITipoPrecoAppService _service;
        public TipoPrecosController(ITipoPrecoAppService service,
            IUser user) : base(user)
        {
            _service = service;
        }

        [HttpGet("listar-tipo-precos-empresa/{idEmpresa:int}")]
        public async Task<IActionResult> Get(int idEmpresa)
        {
            return Ok(await _service.ListarTipoPrecos(idEmpresa));
        }

        [HttpPost("adicionar-tipo-preco")]
        public async Task<IActionResult> Post(TipoPrecoViewModel tipoPreco)
        {
            return Ok(await _service.AdicionarTipoPreco(tipoPreco));
        }       
    }
}
