using System.Data.Entity.ModelConfiguration;
using WarframeDataParser.Db.EntityTypes;
using WarframeDataParser.Db.Extensions;

namespace WarframeDataParser.Db.EntityTypeConfigurations {
    internal class CommentConfiguration : EntityTypeConfiguration<Comment> {
        public CommentConfiguration() {
            this.ConfigureAll();

            Property(c => c.Message)
                .HasColumnName("Message")
                .IsRequired()
                .HasMaxLength(ConfigurationValues.DescriptionStringLength);
            HasOptional(c => c.Reply).WithOptionalPrincipal();
        }
    }
}
