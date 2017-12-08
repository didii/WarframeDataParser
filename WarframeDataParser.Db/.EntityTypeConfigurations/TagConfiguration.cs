using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarframeDataParser.Db.EntityTypes;
using WarframeDataParser.Db.Extensions;

namespace WarframeDataParser.Db.EntityTypeConfigurations {
    internal class TagConfiguration : EntityTypeConfiguration<Tag> {
        public TagConfiguration() {
            this.ConfigureAll();

            Property(t => t.Name).HasColumnName("Name").IsRequired();
            HasRequired(t => t.Category).WithRequiredDependent();
        }
    }
}