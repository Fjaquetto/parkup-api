using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkUp.Application.Interfaces;
using ParkUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkUp.Services.Api.Controllers
{
    [ApiController]
    //[Authorize]
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
                return Ok(await _patioAppService.ListarRegistroPatio());
            }
            catch (Exception ex)
            {
                //return Json(new { status="error", message="Erro ao listar pátio"});
                throw ex;
            }
        }
    }
}
