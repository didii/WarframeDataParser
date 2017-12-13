using WarframeDataParser.Business.Dtos;

namespace WarframeDataParser.Business {
    internal class ModelValidator<TModel> : IModelValidator<TModel> where TModel : DtoBase {
        /// <inheritdoc />
        public bool ValidateCreate { get; } = false;

        /// <inheritdoc />
        public bool ValidateUpdate { get; } = false;

        /// <inheritdoc />
        public bool ValidateDelete { get; } = false;

        /// <inheritdoc />
        public ValidationInfo ValidateForCreate(TModel model) {
            return null;
        }

        /// <inheritdoc />
        public ValidationInfo ValidateForUpdate(TModel prevModel, TModel newModel) {
            return null;
        }

        /// <inheritdoc />
        public ValidationInfo ValidateForDelete(TModel model) {
            return null;
        }
    }
}