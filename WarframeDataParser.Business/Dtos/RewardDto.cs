using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarframeDataParser.Business.Dtos {
    class RewardDto : DtoBase {
        public long Id { get; set; }
        public string Name { get; set; }
        public string RewardType { get; set; }
        public IEnumerable<MissionDto> Missions { get; set; }
    }

    class CreateReward : DtoCreateBase {
        public string Name { get; set; }
        public string RewardType { get; set; }
    }

    class UpdateReward : DtoUpdateBase {
        
    }
}
