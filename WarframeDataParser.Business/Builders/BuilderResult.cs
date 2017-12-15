namespace WarframeDataParser.Business.Builders {
    class BuilderResult : IBuilderResult {
        /// <inheritdoc />
        public int InsertedCount { get; set; }

        /// <inheritdoc />
        public int UpdatedCount { get; set; }

        /// <inheritdoc />
        public int UnchangedCount { get; set; }

        /// <inheritdoc />
        public int InvalidCount { get; set; }
    }
}