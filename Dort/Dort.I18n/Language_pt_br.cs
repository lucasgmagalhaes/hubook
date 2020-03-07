using Dort.Enum;
using Dort.I18n.Exceptions;
using System.Collections.Generic;

namespace Dort.I18n
{
    public class Language_pt_br : ICulture
    {
        private Dictionary<Resource, string> Language { get; }

        public Language_pt_br()
        {
            Language = new Dictionary<Resource, string>
            {
                { Resource.ENUM_WITHOUT_DESCRIPTION, "Enum sem descrição" }
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