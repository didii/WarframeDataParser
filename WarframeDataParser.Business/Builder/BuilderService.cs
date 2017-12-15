using System;
using WarframeDataParser.Business.Fetcher;
using WarframeDataParser.Business.Parsers;
using WarframeDataParser.Business.Selectors;

namespace WarframeDataParser.Business.Builder {
    class BuilderService : IBuilderService {
        private readonly IDataFetcher _fetcher;
        private readonly ISelector<IRewardSelection> _selector;
        private readonly IParser<IRewardSelection> _parser;

        public BuilderService(IDataFetcher fetcher, ISelector<IRewardSelection> selector, IParser<IRewardSelection> parser) {
            _fetcher = fetcher;
            _selector = selector;
            _parser = parser;
        }

        /// <inheritdoc />
        public IBuilderResult Build() {
            var doc = _fetcher.Fetch();
            var selections = _selector.Select(doc);
            var result = new BuilderResult();
            foreach (var selection in selections) {
                var parseResult = _parser.Parse(selection);
                switch (parseResult) {
                    case EParseResult.Invalid:
                        result.InsertedCount++;
                        break;
                    case EParseResult.Unchanged:
                        result.UnchangedCount++;
                        break;
                    case EParseResult.Updated:
                        result.UpdatedCount++;
                        break;
                    case EParseResult.Inserted:
                        result.InsertedCount++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return result;
        }
    }
}