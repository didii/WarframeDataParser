using AutoMapper;
using WarframeDataParser.Business.Dtos;
using WarframeDataParser.Db.Entities;
using WarframeDataParser.Db.Repositories;
using Microsoft.AspNetCore.JsonPatch;

namespace WarframeDataParser.Business.Services {
    class PatchService<TModel, TUpdateModel, TEntity> : IPatchService<TModel, TUpdateModel> where TModel : DtoBase where TUpdateModel : DtoUpdateBase where TEntity : class, IDbItem {
        private readonly IMapper _mapper;
        private readonly IReadRepository<TEntity> _readRepository;
        private readonly IWriteRepository<TEntity> _writeRepository;
        private readonly IModelValidator<TModel> _validator;

        /// <inheritdoc />
        public PatchService(IMapper mapper, IReadRepository<TEntity> readRepository, IWriteRepository<TEntity> writeRepository, IModelValidator<TModel> validator) {
            _mapper = mapper;
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _validator = validator;
        }

        /// <inheritdoc />
        public TModel Patch(int id, JsonPatchDocument<TUpdateModel> updateDocument) {
            var entity = _readRepository.Get(id);
            var model = _mapper.Map<TModel>(entity);
            var patchDocument = _mapper.Map<JsonPatchDocument<TModel>>(updateDocument);
            patchDocument.ApplyTo(model);
            if (_validator.ValidateUpdate) {
                var prevModel = _mapper.Map<TModel>(entity);
                var validation = _validator.ValidateForUpdate(prevModel, model);
                if (validation != null)
                    throw new BusinessModelValidationException(validation);
            }
            _mapper.Map(model, entity);
            var newEntity = _writeRepository.Update(entity);
            _writeRepository.SaveChanges();
            var newModel = _mapper.Map<TModel>(newEntity);
            return newModel;
        }
    }
}