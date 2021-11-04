using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkUp.Application.Interfaces;
using ParkUp.Application.ViewModels;
using ParkUp.Domain.Interfaces;
using ParkUp.Domain.Models.RequestModels.TipoPreco;
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

        [HttpPost]       
        public async Task<IActionResult> Post(TipoPrecoViewModel tipoPreco)
        {
            await _service.AdicionarTipoPreco(tipoPreco);

            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTipoPreco(int id)
        {
            return Ok(await _service.GetTipoPreco(id));
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(TipoPrecoModelRequest request)
        {
            var tipoPreco = await _service.GetTipoPreco(request.Id);

            return tipoPreco == null ? NoContent() : (ActionResult)Ok(await _service.AtualizarTipoPreco(request));
        }
    }
}
