using Dort.Enum;
using Dort.I18n.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Dort.I18n
{
    public static class CultureManager
    {
        private static readonly Dictionary<string, ICulture> _cultures;
        public static string Lang { get; set; }

        static CultureManager()
        {
            _cultures = new Dictionary<string, ICulture>();
        }

        public static void AddResource(string lang, ICulture resource)
        {
            _cultures.Add(lang, resource);
        }

        public static ICulture GetResource()
        {
            if (string.IsNullOrEmpty(Lang))
                throw new LanguageException("Language was not setted");

            if (_cultures.TryGetValue(Lang, out ICulture resource))
                return resource;

            throw new LanguageException("Resource for informed language was not found");
        }

        public static string Get(Resource resourceName)
        {
            if (string.IsNullOrEmpty(Lang))
                throw new LanguageException("Language was not setted");

            if (_cultures.TryGetValue(Lang, out ICulture resource))
                return resource.Value(resourceName);

            throw new LanguageException("Resource for informed language was not found");
        }
    }
}
