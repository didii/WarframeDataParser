using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WarframeDataParser.Db.Entities;

namespace WarframeDataParser.Db.Repositories {
    public interface IReadRepository<TEntity> where TEntity : class, IDbItem {
        TEntity Get(long id);
        IEnumerable<TEntity> GetAll();
        TEntity Query(Func<IQueryable<TEntity>, TEntity> query);
        IEnumerable<TEntity> Query(Func<IQueryable<TEntity>, IQueryable<TEntity>> query);
    }
}
