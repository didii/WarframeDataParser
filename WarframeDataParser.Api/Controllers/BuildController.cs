using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarframeDataParser.Business.Builder;

namespace WarframeDataParser.Api.Controllers {
    [Route("build")]
    public class BuildController : Controller {
        private readonly IBuilderService _builderService;

        public BuildController(IBuilderService builderService) {
            _builderService = builderService;
        }

        /// <summary>
        /// Recreates the data based on the official source
        /// </summary>
        /// <remarks>Source: https://n8k6e2y6.ssl.hwcdn.net/repos/hnfvc0o3jnfvc873njb03enrf56.html </remarks>
        /// <returns>Always OK</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Build() {
            var result = _builderService.Build();
            return Ok(result);
        }

        [HttpPost("check")]
        public IActionResult Check() {
            throw new NotImplementedException();
        }
    }
}