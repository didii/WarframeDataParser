using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarframeDataParser.Business.Selectors;

namespace WarframeDataParser.Business.Builders {
    class Builder : IBuilder {
        private readonly IBuilderService<IRewardSelection> _rewardBuilder;
        private readonly IBuilderService<IMissionSelection> _missionBuilder;

        public Builder(IBuilderService<IRewardSelection> rewardBuilder, IBuilderService<IMissionSelection> missionBuilder) {
            _rewardBuilder = rewardBuilder;
            _missionBuilder = missionBuilder;
        }

        /// <inheritdoc />
        public IEnumerable<IBuilderResult> Build() {
            return new []{_rewardBuilder.Build(), _missionBuilder.Build()};
        }
    }

    public interface IBuilder {
        IEnumerable<IBuilderResult> Build();
        
    }
}
