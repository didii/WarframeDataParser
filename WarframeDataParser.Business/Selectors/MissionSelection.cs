namespace WarframeDataParser.Business.Selectors {
    class MissionSelection : IMissionSelection {
        /// <inheritdoc />
        public string Name { get; set; }

        /// <inheritdoc />
        public string MissionType { get; set; }

        /// <inheritdoc />
        public string Planet { get; set; }
    }
}