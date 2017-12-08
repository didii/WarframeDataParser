using System.Data.Entity;

namespace WarframeDataParser.Db.Contexts {
    internal class ContextInitializer : CreateDatabaseIfNotExists<Context> {
        /// <inheritdoc />
        protected override void Seed(Context context) {
            base.Seed(context);
        }
    }
}