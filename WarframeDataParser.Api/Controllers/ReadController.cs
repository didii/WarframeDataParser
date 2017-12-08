using System;
using System.Net;
using WarframeDataParser.Business.Dtos;
using WarframeDataParser.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WarframeDataParser.Api.Controllers {
    [Route("api/[controller]")]
    public abstract class ReadController<TModel> : Controller where TModel : DtoBase {
        protected readonly IGetService<TModel> Service;

        protected ReadController(IGetService<TModel> service) {
            Service = service;
        }

        /// <summary>
        /// Get all objects of this type
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public virtual IActionResult GetAll() {
            var result = Service.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Get an object of this type by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public virtual IActionResult Get(long id) {
            var result = Service.Get(id);
            return Ok(result);
        }
    }
}