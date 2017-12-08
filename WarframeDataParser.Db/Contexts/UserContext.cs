using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarframeDataParser.Contracts;
using WarframeDataParser.Db.EntityTypes;

namespace WarframeDataParser.Db.Contexts {
    public class UserContext2 : DbContext, IDbContext {
        public DbSet<User> Users { get; set; }

        public UserContext2() : base("user") {
            Initialize();
        }

        public UserContext2(string connectionString) : base(connectionString) {
            Initialize();
        }

        private void Initialize() {
            Database.SetInitializer(new UserContextInitializer());
        }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        }

        /// <inheritdoc />
        public override int SaveChanges() {
            var now = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries()
                                               .Where(e => e.State == EntityState.Added ||
                                                           e.State == EntityState.Modified)) {
                if (entry.Entity is ITracable tracable) {
                    if (entry.State == EntityState.Added)
                        tracable.CreatedOn = now;
                    tracable.UpdatedOn = now;
                }
            }
            return base.SaveChanges();
        }
    }
}
