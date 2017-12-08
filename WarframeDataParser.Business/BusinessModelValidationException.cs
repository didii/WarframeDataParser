using System;

namespace WarframeDataParser.Business {
    public class BusinessModelValidationException : ApplicationException {
        private ValidationInfo _info;

        /// <inheritdoc />
        public BusinessModelValidationException(ValidationInfo validation) : base(validation.Message) { }

        /// <inheritdoc />
        public BusinessModelValidationException(ValidationInfo validation, Exception innerException) : base(validation.Message, innerException) { }
    }
}