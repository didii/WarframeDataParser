using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarframeDataParser.Db.EntityTypes;
using WarframeDataParser.Db.Extensions;

namespace WarframeDataParser.Db.EntityTypeConfigurations {
    internal class RecipeInfoConfiguration : EntityTypeConfiguration<RecipeInfo> {
        public RecipeInfoConfiguration() {
            this.ConfigureAll();

            Property(ri => ri.Servings).HasColumnName("Servings").IsRequired();
            Property(ri => ri.Duration).HasColumnName("Duration").IsOptional();
            HasMany(ri => ri.Tags).WithOptional();
        }
    }
}