namespace WarframeDataParser.Business.Selectors {
    public interface IMissionSelection : ISelection {
        string MissionType { get; }
        string Planet { get; }
    }
}