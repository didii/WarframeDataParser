using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarframeDataParser.Db.EntityTypes;
using WarframeDataParser.Db.Extensions;

namespace WarframeDataParser.Db.EntityTypeConfigurations {
    internal class RecipeHowToConfiguration : EntityTypeConfiguration<RecipeHowTo> {
        public RecipeHowToConfiguration() {
            this.ConfigureAll();

            Property(h => h.Description)
                .HasColumnName("Description")
                .HasMaxLength(ConfigurationValues.DescriptionStringLength)
                .IsRequired();
            HasMany(h => h.Comment).WithRequired();
        }
    }
}