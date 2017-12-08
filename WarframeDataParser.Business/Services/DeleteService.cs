using AutoMapper;
using WarframeDataParser.Business.Dtos;
using WarframeDataParser.Db.Entities;
using WarframeDataParser.Db.Repositories;

namespace WarframeDataParser.Business.Services {
    internal class DeleteService<TModel, TEntity> : IDeleteService<TModel> where TModel : DtoBase where TEntity : class, IDbItem {
        private readonly IMapper _mapper;
        private readonly IReadRepository<TEntity> _readRepository;
        private readonly IWriteRepository<TEntity> _writeRepository;
        private readonly IModelValidator<TModel> _validator;

        public DeleteService(IMapper mapper, IReadRepository<TEntity> readRepository, IWriteRepository<TEntity> writeRepository, IModelValidator<TModel> validator) {
            _mapper = mapper;
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _validator = validator;
        }

        /// <inheritdoc />
        public TModel Delete(long id) {
            return _validator.ValidateDelete ? ValidateDelete(id) : SimpleDelete(id);
        }

        private TModel SimpleDelete(long id) {
            var entity = _writeRepository.Delete(id);
            _writeRepository.SaveChanges();
            var model = _mapper.Map<TModel>(entity);
            return model;
        }

        private TModel ValidateDelete(long id) {
            var entity = _readRepository.Get(id);
            var model = _mapper.Map<TModel>(entity);
            var validation = _validator.ValidateForDelete(model);
            if (validation != null)
                throw new BusinessModelValidationException(validation);
            _writeRepository.Delete(entity);
            _writeRepository.SaveChanges();
            return model;
        }
    }
}