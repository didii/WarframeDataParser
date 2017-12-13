using HtmlAgilityPack;

namespace WarframeDataParser.Business.Fetcher {
    class LocalDataFetcher : IDataFetcher {

        public static string DefaultUri { get; } = @"C:\Users\DiVa\Source\Repos\WarframeDataParser\WarframeData.html";

        /// <inheritdoc />
        public HtmlDocument Fetch(string uri) {
            var result = new HtmlDocument();
            result.Load(uri ?? DefaultUri);
            return result;
        }
    }
}