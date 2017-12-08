using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarframeDataParser.Db.EntityTypes;
using WarframeDataParser.Db.Extensions;

namespace WarframeDataParser.Db.EntityTypeConfigurations {
    internal class UserConfiguration : EntityTypeConfiguration<User> {
        public UserConfiguration() {
            this.ConfigureIDbItem();
            this.ConfigureITracable();

            Property(u => u.Name).HasColumnName("Name").IsRequired().HasMaxLength(ConfigurationValues.NameStringLength);
            Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired().IsFixedLength().HasMaxLength(32);
            Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired().IsFixedLength().HasMaxLength(16);
            HasRequired(u => u.Role).WithRequiredDependent();
        }
    }
}
