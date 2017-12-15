using System;
using WarframeDataParser.Business.Fetcher;
using WarframeDataParser.Business.Parsers;
using WarframeDataParser.Business.Selectors;

namespace WarframeDataParser.Business.Builders {
    class BuilderService<T> : IBuilderService<T> where T : ISelection {
        protected IDataFetcher DataFetcher { get; }
        protected ISelector<T> Selector { get; }
        protected IParser<T> Parser { get; }

        /// <inheritdoc />
        public BuilderService(IDataFetcher dataFetcher, ISelector<T> selector, IParser<T> parser) {
            DataFetcher = dataFetcher;
            Selector = selector;
            Parser = parser;
        }

        /// <inheritdoc />
        public IBuilderResult Build() {
            var document = DataFetcher.Fetch();
            var selections = Selector.Select(document);
            var result = new BuilderResult();
            foreach (var selection in selections) {
                var parseResult = Parser.Parse(selection);
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