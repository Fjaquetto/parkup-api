using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkUp.Application.Interfaces;
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
    }
}
