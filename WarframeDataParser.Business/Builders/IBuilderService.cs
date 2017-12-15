namespace WarframeDataParser.Business.Builders {
    public interface IBuilderService<T> {
        /// <summary>
        /// Builds the database data and returns the amount of entries that were changed
        /// </summary>
        /// <returns></returns>
        IBuilderResult Build();
    }
}
