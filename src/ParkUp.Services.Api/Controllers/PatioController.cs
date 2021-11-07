﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize]
    [Route("api/patio")]

    public class PatioController : ApiController
    {
        private readonly IPatioAppService _patioAppService;

        public PatioController(IPatioAppService patioAppService, IUser user) : base(user)
        {
            _patioAppService = patioAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _patioAppService.GetRegistrosPatio());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[HttpGet("{idPatio}")]
        //public async Task<IActionResult> Get(int idPatio)
        //{
        //    try
        //    {
        //        return Ok(await _patioAppService.GetRegistrosPatioById(idPatio));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> Post(PatioViewModel registroPatio)
        {
            try
            {
                if (registroPatio == null)
                    return NotFound();

                return Ok(await _patioAppService.PostRegistroPatio(registroPatio));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(PatioViewModel registroPatio)
        {
            try
            {
                if (registroPatio == null)
                    return NotFound();

                return Ok(await _patioAppService.PutRegistroPatio(registroPatio));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Atualiza o valor e o tempo de permanencia do veículo
        /// </summary>      
        /// <param name="registroPatio">Recebe objeto do Tipo PatioViewModel</param>
        /// <returns></returns>
        [HttpPatch("saida-veiculo")]         
        public async Task<IActionResult> PatchAtualizarSaidaVeiculo(PatioViewModel registroPatio)
        {
            try
            {
                if (registroPatio == null)
                    return NotFound();

                return Ok(await _patioAppService.PatchSaidaVeiculo(registroPatio));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("saldo-caixa")]
        public async Task<IActionResult> GetSaldoCaixaByPeriodo(int idEmpresa,DateTime periodo)
        {
            try
            {
                return Ok(await _patioAppService.GetCaixaSaldoByPeriodo(idEmpresa,periodo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("veiculo-por-placa")]
        public async Task<IActionResult> GetVeiculoByPlaca(int idEmpresa, string placa)
        {
            try
            {
                var veiculo = await _patioAppService.GetVeiculoPatioByPlaca(idEmpresa, placa);

                return (veiculo is null) ? NoContent() : (ActionResult)Ok(veiculo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
