using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarframeDataParser.Business.Builder {
    public interface IBuilderService {
        /// <summary>
        /// Builds the database data and returns the amount of entries that were changed
        /// </summary>
        /// <returns></returns>
        int Build();
    }
}
