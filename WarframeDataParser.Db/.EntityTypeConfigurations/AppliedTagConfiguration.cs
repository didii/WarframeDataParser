using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarframeDataParser.Db.EntityTypes;
using WarframeDataParser.Db.Extensions;

namespace WarframeDataParser.Db.EntityTypeConfigurations
{
    internal class AppliedTagConfiguration : EntityTypeConfiguration<AppliedTag> {
        public AppliedTagConfiguration() {
            this.ConfigureAll();

            HasRequired(t => t.Recipe).WithRequiredDependent();
            HasRequired(t => t.Tag).WithRequiredDependent();
        }
    }
}
