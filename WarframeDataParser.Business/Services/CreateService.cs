using AutoMapper;
using WarframeDataParser.Business.Dtos;
using WarframeDataParser.Db.Entities;
using WarframeDataParser.Db.Repositories;

namespace WarframeDataParser.Business.Services {
    internal class CreateService<TModel, TCreateModel, TEntity> : ICreateService<TModel, TCreateModel> where TModel : DtoBase
                                                                                                       where TCreateModel : DtoCreateBase
                                                                                                       where TEntity : class, IDbItem {
        private readonly IMapper _mapper;
        private readonly IWriteRepository<TEntity> _writeRepository;
        private readonly IModelValidator<TModel> _validator;

        public CreateService(IMapper mapper, IWriteRepository<TEntity> writeRepository, IModelValidator<TModel> validator) {
            _mapper = mapper;
            _writeRepository = writeRepository;
            _validator = validator;
        }

        /// <inheritdoc />
        public TModel Create(TCreateModel createModel) {
            return _validator.ValidateCreate ? ValidateCreate(createModel) : SimpleCreate(createModel);
        }

        private TModel SimpleCreate(TCreateModel createModel) {
            var model = _mapper.Map<TModel>(createModel);
            var entity = _mapper.Map<TEntity>(model);
            var newEntity = _writeRepository.Add(entity);
            _writeRepository.SaveChanges();
            var newModel = _mapper.Map<TModel>(newEntity);
            return newModel;
        }

        private TModel ValidateCreate(TCreateModel createModel) {
            var model = _mapper.Map<TModel>(createModel);
            var validation = _validator.ValidateForCreate(model);
            if (validation != null)
                throw new BusinessModelValidationException(validation);

            var entity = _mapper.Map<TEntity>(model);
            var newEntity = _writeRepository.Add(entity);
            _writeRepository.SaveChanges();
            var newModel = _mapper.Map<TModel>(newEntity);
            return newModel;
        }
    }
}
