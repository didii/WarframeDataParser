using WarframeDataParser.Business.Fetcher;
using WarframeDataParser.Business.Parsers;
using WarframeDataParser.Business.Selectors;

namespace WarframeDataParser.Business.Builder {
    class BuilderService : IBuilderService {
        private readonly IDataFetcher _fetcher;
        private readonly IRewardSelector _selector;
        private readonly IRewardParser _parser;

        public BuilderService(IDataFetcher fetcher, IRewardSelector selector, IRewardParser parser) {
            _fetcher = fetcher;
            _selector = selector;
            _parser = parser;
        }

        /// <inheritdoc />
        public int Build() {
            var doc = _fetcher.Fetch();
            var selections = _selector.Select(doc);
            var count = 0;
            foreach (var selection in selections) {
                count += _parser.Parse(selection) ? 1 : 0;
            }
            return count;
        }
    }
}