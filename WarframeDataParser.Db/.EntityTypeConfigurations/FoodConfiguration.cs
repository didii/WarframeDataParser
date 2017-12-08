using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarframeDataParser.Db.EntityTypes;
using WarframeDataParser.Db.Extensions;

namespace WarframeDataParser.Db.EntityTypeConfigurations {
    internal class FoodConfiguration : EntityTypeConfiguration<Food> {
        public FoodConfiguration() {
            this.ConfigureAll();

            Property(f => f.Name).HasColumnName("Name").IsRequired().HasMaxLength(ConfigurationValues.NameStringLength);
            Property(f => f.NamePlural)
                .HasColumnName("NamePlural")
                .IsOptional()
                .HasMaxLength(ConfigurationValues.NameStringLength);
            Property(f => f.Description)
                .HasColumnName("Description")
                .IsOptional()
                .HasMaxLength(ConfigurationValues.DescriptionStringLength);
            HasOptional(f => f.Image).WithRequired();
            HasMany(f => f.Comments).WithRequired();
        }
    }
}