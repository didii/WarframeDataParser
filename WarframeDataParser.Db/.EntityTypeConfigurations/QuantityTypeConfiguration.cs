using System.Data.Entity.ModelConfiguration;
using WarframeDataParser.Db.EntityTypes;
using WarframeDataParser.Db.Extensions;

namespace WarframeDataParser.Db.EntityTypeConfigurations {
    internal class QuantityTypeConfiguration : EntityTypeConfiguration<QuantityType> {
        public QuantityTypeConfiguration() {
            this.ConfigureAll();

            Property(qt => qt.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(ConfigurationValues.NameStringLength);
        }
    }
}