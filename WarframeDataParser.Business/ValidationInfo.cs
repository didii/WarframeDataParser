using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WarframeDataParser.Business {
    public class ValidationInfo {
        public virtual string TypeName { get; }
        protected virtual Dictionary<string, string> Messages { get; }

        public ValidationInfo(string typeName) {
            TypeName = typeName;
            Messages = new Dictionary<string, string>();
        }

        public void Add(string propertyName, string message) {
            Messages.Add(propertyName, message);
        }

        public void Add(PropertyInfo property, string message) {
            Messages.Add(property.Name, message);
        }

        public string Message {
            get {
                var builder = new StringBuilder();
                builder.AppendLine(TypeName + "\n");
                foreach (var keyvalue in Messages) {
                    builder.AppendLine(keyvalue.Key + ":");
                    builder.AppendLine(keyvalue.Value);
                }
                return builder.ToString();
            }
        }
    }
}