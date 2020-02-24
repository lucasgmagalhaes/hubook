using Microsoft.Extensions.Localization;

namespace Dort.i18n.Resources
{
    public class DortResourcesManager : IAppResource
    {
        private readonly IStringLocalizer<DortResourcesManager> _localizer;
        public DortResourcesManager(IStringLocalizer<DortResourcesManager> localizer)
        {
            _localizer = localizer;
        }

        public string GetResource(string key)
        {
            return _localizer[key];
        }
    }
}
