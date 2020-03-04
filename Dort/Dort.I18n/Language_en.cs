using Dort.Enum;
using Dort.Exceptions;
using System.Collections.Generic;

namespace Dort.I18n
{
    public class Language_en : IResourceCollection
    {
        private Dictionary<Resource, string> Language { get; }

        public Language_en()
        {
            Language = new Dictionary<Resource, string>
            {
                { Resource.ENUM_WITHOUT_DESCRIPTION, "Enum without description" }
            };
        }

        public string Value(Resource resource)
        {
            if (Language.TryGetValue(resource, out string value))
            {
                return value;
            }
            throw new ResourceWitoutDescriptionException();
        }
    }
}
