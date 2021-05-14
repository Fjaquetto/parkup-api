using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkUp.Application.Interfaces;
using ParkUp.Application.ViewModels;
using ParkUp.Domain.Interfaces;

namespace ParkUp.Services.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/empresas")]
    public class EmpresasController : ApiController
    {
        private readonly IEmpresasAppService _empresasAppService;
        public EmpresasController(IEmpresasAppService empresasAppService,
            IUser user) : base(user)
        {
            _empresasAppService = empresasAppService;
        }

        [HttpGet("listar-empresas")]
        public async Task<IActionResult> ListarEmpresas()
        {
            return Ok(await _empresasAppService.ListarEmpresas());
        }

        [HttpGet("obter-empresa-por-id/{id:int}")]
        public async Task<IActionResult> ObterEmpresaPorId(int id)
        {
            return Ok(await _empresasAppService.ObterEmpresaPorId(id));
        }

        [HttpPost("adicionar-empresa")]
        public async Task<IActionResult> AdicionarEmpresa(EmpresasViewModel empresas)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(await _empresasAppService.AdicionarEmpresa(empresas));
        }

        [HttpPut("atualizar-empresa")]
        public async Task<IActionResult> AtualizarEmpresa(EmpresasViewModel empresas)
        {
            return Ok(await _empresasAppService.AtualizarEmpresa(empresas));
        }

        [HttpDelete("desativar-empresa")]
        public async Task<IActionResult> DesativarEmpresa(EmpresasViewModel empresas)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _empresasAppService.DesativarEmpresa(empresas.Id))            
                return Ok();           
            else            
                return NotFound();          
        }
    }
}
