using System;
using System.Data.Entity;

namespace WarframeDataParser.Db.Contexts {
    public interface IDbContext : IDisposable {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}
