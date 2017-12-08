using System.Net;
using WarframeDataParser.Business.Dtos;
using WarframeDataParser.Business.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace WarframeDataParser.Api.Controllers {
    public abstract class WriteController<TModel, TCreateModel, TUpdateModel> : ReadController<TModel> where TModel : DtoBase
                                                                                                       where TCreateModel : DtoCreateBase
                                                                                                       where TUpdateModel : DtoUpdateBase {
        public ICreateService<TModel, TCreateModel> CreateService { get; }
        public IUpdateService<TModel, TUpdateModel> UpdateService { get; }
        public IPatchService<TModel, TUpdateModel> PatchService { get; }
        public IDeleteService<TModel> DeleteService { get; }

        protected WriteController(IGetService<TModel> getService,
                                  ICreateService<TModel, TCreateModel> createService,
                                  IUpdateService<TModel, TUpdateModel> updateService,
                                  IPatchService<TModel, TUpdateModel> patchService,
                                  IDeleteService<TModel> deleteService) : base(getService) {
            CreateService = createService;
            UpdateService = updateService;
            PatchService = patchService;
            DeleteService = deleteService;
        }

        /// <summary>
        ///     Create an object of this type
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public virtual IActionResult Post([FromBody] TCreateModel dto) {
            var result = CreateService.Create(dto);
            return Ok(result);
        }

        /// <summary>
        ///     Update an existing object of this type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public virtual IActionResult Put(int id, [FromBody] TUpdateModel dto) {
            var result = UpdateService.Update(id, dto);
            return Ok(result);
        }

        /// <summary>
        /// Patches an existing object of this type
        /// </summary>
        /// <param name="id">The ID of the object to be patched</param>
        /// <param name="patch">The patch document</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public virtual IActionResult Patch(int id, [FromBody] JsonPatchDocument<TUpdateModel> patch) {
            var result = PatchService.Patch(id, patch);
            return Ok(result);
        }

        /// <summary>
        ///     Deletes an object of this type by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public virtual IActionResult Delete(int id) {
            var result = DeleteService.Delete(id);
            return Ok(result);
        }
    }
}
