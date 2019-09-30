using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ioasys.Application.Interfaces;
using Ioasys.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace Ioasys.Enterprise.Controllers
{
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EnterprisesController : ControllerBase
    {
        private IEnterpriseAppService _enterpriseAppService;

        public EnterprisesController(IEnterpriseAppService enterpriseAppService)
        {
            _enterpriseAppService = enterpriseAppService;
        }

        [HttpGet]
        public IActionResult Get(int? enterprise_types, string name)
        {
            IEnumerable<EnterpriseViewModel> dados;

            if (enterprise_types != null)
                dados = _enterpriseAppService.GetEnterprisesByNameAndType(name, enterprise_types.Value);
            else
                dados = _enterpriseAppService.GetAllEnterprises();

            return Ok(dados);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            var dados = _enterpriseAppService.GetEnterpriseById(id);

            return Ok(dados);
        }
    }
}