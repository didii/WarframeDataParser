using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WarframeDataParser.Db.Contexts;
using WarframeDataParser.Db.Entities;

namespace WarframeDataParser.Db.Repositories {
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : class, IDbItem {
        private readonly Context _context;
        private readonly DbSet<TEntity> _set;

        public ReadRepository(Context context) {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        /// <inheritdoc />
        public TEntity Get(long id) {
            return _set.SingleOrDefault(e => e.Id == id);
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> GetAll() {
            return _set.ToArray();
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> Query(Func<IQueryable<TEntity>,IQueryable<TEntity>> query) {
            return query(_set.AsQueryable()).ToArray();
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate) {
            return _set.Where(predicate);
        }
    }
}
