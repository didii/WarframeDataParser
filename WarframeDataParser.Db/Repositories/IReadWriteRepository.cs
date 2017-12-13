using System;
using WarframeDataParser.Db.Entities;

namespace WarframeDataParser.Db.Repositories {
    public interface IReadWriteRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity> where TEntity : class, IDbItem {

        TEntity CreateOrGet(TEntity entity, Func<TEntity, TEntity, bool> predicate);
    }
}