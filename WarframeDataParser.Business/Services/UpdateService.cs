using AutoMapper;
using WarframeDataParser.Business.Dtos;
using WarframeDataParser.Db.Entities;
using WarframeDataParser.Db.Repositories;

namespace WarframeDataParser.Business.Services {
    internal class UpdateService<TModel, TUpdateModel, TEntity> : IUpdateService<TModel, TUpdateModel> where TEntity : class, IDbItem
                                                                                                       where TModel : DtoBase
                                                                                                       where TUpdateModel : DtoUpdateBase {
        private readonly IMapper _mapper;
        private readonly IReadRepository<TEntity> _readRepository;
        private readonly IWriteRepository<TEntity> _writeRepository;
        private readonly IModelValidator<TModel> _validator;

        public UpdateService(IMapper mapper,
                             IReadRepository<TEntity> readRepository,
                             IWriteRepository<TEntity> writeRepository,
                             IModelValidator<TModel> validator) {
            _mapper = mapper;
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _validator = validator;
        }

        /// <inheritdoc />
        public TModel Update(long id, TUpdateModel updateModel) {
            var entity = _readRepository.Get(id); //get entity
            var model = _mapper.Map<TModel>(entity); //map to model
            _mapper.Map(updateModel, model); //update model
            if (_validator.ValidateUpdate) {
                var prevModel = _mapper.Map<TModel>(model); //clone model
                var validation = _validator.ValidateForUpdate(prevModel, model);
                if (validation != null)
                    throw new BusinessModelValidationException(validation);
            }
            _mapper.Map(model, entity); //update entity with updated model
            var newEntity = _writeRepository.Update(entity);
            _writeRepository.SaveChanges();
            var result = _mapper.Map<TModel>(newEntity);
            return result;
        }
    }
}
