﻿namespace WarframeDataParser.Business.Builder {
    public interface IBuilderResult {
        int InsertedCount { get; }
        int UpdatedCount { get; }
        int UnchangedCount { get; }
        int InvalidCount { get; }
    }
}