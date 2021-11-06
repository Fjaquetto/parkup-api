using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _empresasAppService.ListarEmpresas());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _empresasAppService.ObterEmpresaPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmpresasViewModel empresas)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (_empresasAppService.VerificaSeEmpresaExiste(empresas).Result) return Conflict(new { status = "A empresa já está cadastrada.", data = empresas });

            return Ok(await _empresasAppService.AdicionarEmpresa(empresas));
        }

        [HttpPut]
        public async Task<IActionResult> Put(EmpresasViewModel empresas)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (_empresasAppService.VerificaSeEmpresaExiste(empresas).Result) return Conflict(new { status = "A empresa já está cadastrada.", data = empresas });

            return Ok(await _empresasAppService.AtualizarEmpresa(empresas));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(EmpresasViewModel empresas)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _empresasAppService.DesativarEmpresa(empresas.Id))
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("excluir")]
        public async Task<IActionResult> ExcluirEmpresa(EmpresasViewModel empresas)
        {
            return Ok(await _empresasAppService.ExcluirEmpresa(empresas));
        }
    }
}
