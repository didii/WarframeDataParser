using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WarframeDataParser.Db.Contexts;
using WarframeDataParser.Db.Entities;

namespace WarframeDataParser.Db.Repositories {
    /// <inheritdoc />
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : class, IDbItem {
        private readonly Context _context;
        private readonly DbSet<TEntity> _set;

        /// <inheritdoc />
        public WriteRepository(Context context) {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        /// <inheritdoc />
        public TEntity Add(TEntity entity) {
            var result = _set.Add(entity);
            return result;
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> AddMany(IEnumerable<TEntity> entities) {
            return _set.AddRange(entities);
        }

        /// <inheritdoc />
        public TEntity Update(TEntity entity) {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
            return entry.Entity;
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> UpdateMany(IEnumerable<TEntity> entities) {
            var result = new List<TEntity>();
            foreach (var entity in entities)
                result.Add(Update(entity));
            return result;
        }

        /// <inheritdoc />
        public TEntity Delete(long id) {
            return Delete(_set.SingleOrDefault(entity => entity.Id == id));
        }

        /// <inheritdoc />
        public TEntity Delete(TEntity entity) {
            var result = _set.Remove(entity);
            return result;
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> DeleteMany(IEnumerable<long> ids) {
            return DeleteMany(_set.Where(entity => ids.Contains(entity.Id)));
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> DeleteMany(IEnumerable<TEntity> entities) {
            return _set.RemoveRange(entities);
        }

        /// <inheritdoc />
        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
