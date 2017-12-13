using System;
using System.Collections.Generic;
using System.Linq;
using WarframeDataParser.Db.Entities;

namespace WarframeDataParser.Db.Repositories {
    public class ReadWriteRepository<TEntity> : IReadWriteRepository<TEntity> where TEntity : class, IDbItem {
        private readonly IReadRepository<TEntity> _readRepo;
        private readonly IWriteRepository<TEntity> _writeRepo;

        public ReadWriteRepository(IReadRepository<TEntity> readRepo, IWriteRepository<TEntity> writeRepo) {
            _readRepo = readRepo;
            _writeRepo = writeRepo;
        }

        /// <inheritdoc />
        public TEntity Get(long id) {
            return _readRepo.Get(id);
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> GetAll() {
            return _readRepo.GetAll();
        }

        /// <inheritdoc />
        public TEntity Query(Func<IQueryable<TEntity>, TEntity> query) {
            return _readRepo.Query(query);
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> Query(Func<IQueryable<TEntity>, IQueryable<TEntity>> query) {
            return _readRepo.Query(query);
        }

        /// <inheritdoc />
        public TEntity Add(TEntity entity) {
            return _writeRepo.Add(entity);
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> AddMany(IEnumerable<TEntity> entities) {
            return _writeRepo.AddMany(entities);
        }

        /// <inheritdoc />
        public TEntity Update(TEntity entity) {
            return _writeRepo.Update(entity);
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> UpdateMany(IEnumerable<TEntity> entities) {
            return _writeRepo.UpdateMany(entities);
        }

        /// <inheritdoc />
        public TEntity Delete(long id) {
            return _writeRepo.Delete(id);
        }

        /// <inheritdoc />
        public TEntity Delete(TEntity entity) {
            return _writeRepo.Delete(entity);
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> DeleteMany(IEnumerable<long> ids) {
            return _writeRepo.DeleteMany(ids);
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> DeleteMany(IEnumerable<TEntity> entities) {
            return _writeRepo.DeleteMany(entities);
        }

        /// <inheritdoc />
        public void SaveChanges() {
            _writeRepo.SaveChanges();
        }

        /// <inheritdoc />
        public TEntity CreateOrGet(TEntity entity, Func<TEntity, TEntity, bool> predicate) {
            throw new NotImplementedException();
        }
    }
}
