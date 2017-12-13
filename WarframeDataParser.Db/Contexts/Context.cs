using System;
using System.Data.Entity;
using System.Linq;
using WarframeDataParser.Db.Entities;

namespace WarframeDataParser.Db.Contexts {
    public class Context : DbContext, IDbContext {

        public DbSet<Reward> Rewards { get; set; }

        public Context() : base("local") {
            Initialize();
        }

        public Context(string connectionString) : base(connectionString) {
            Initialize();
            this.Database.CreateIfNotExists();
        }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<DropSource>().HasOptional(s => s.Relic).WithRequired();
            modelBuilder.Entity<Reward>().HasOptional(s => s.Relic).WithRequired();
            //base.OnModelCreating(modelBuilder);
        }

        /// <inheritdoc cref="DbContext.SaveChanges" />
        public override int SaveChanges() {
            return base.SaveChanges();
        }

        private void Initialize() {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Database.SetInitializer(new ContextInitializer());
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }
    }
}