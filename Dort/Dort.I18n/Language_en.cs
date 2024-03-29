﻿using Dort.Enum;
using Dort.I18n.Exceptions;
using System.Collections.Generic;

namespace Dort.I18n
{
    public class Language_en : ICulture
    {
        private Dictionary<Resource, string> Language { get; }

        public Language_en()
        {
            Language = new Dictionary<Resource, string>
            {
                { Resource.ENUM_WITHOUT_DESCRIPTION, "Enum without description" },
                { Resource.RESOURCE_WITHOUT_DESCRIPTION, "No description for resource was informed in selected culture." },
                { Resource.LANGUAGE_WAS_NOT_SETTED, "Language was not setted." }
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
