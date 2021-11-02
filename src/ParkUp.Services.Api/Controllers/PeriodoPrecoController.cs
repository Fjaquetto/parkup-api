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
    [Route("api/periodo-precos")]
    public class PeriodoPrecoController : ApiController
    {
        private readonly IPeriodoPrecoAppService _service;
        public PeriodoPrecoController(IPeriodoPrecoAppService service,
            IUser user) : base(user)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PeriodoPrecoViewModel periodoPreco)
        {
            await _service.AdicionarPrecoPeriodo(periodoPreco);

            return Ok();
        }
    }
}
