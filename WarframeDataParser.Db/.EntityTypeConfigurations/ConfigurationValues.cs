using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarframeDataParser.Db.EntityTypeConfigurations {
    public static class ConfigurationValues {
        public static int ShortStringLength { get; } = 10;
        public static int NameStringLength { get; } = 50;
        public static int DescriptionStringLength { get; } = 500;
    }
}
