using Dort.Enum;
using Dort.I18n;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dort.WebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DortRequired : RequiredAttribute
    {
        public DortRequired()
        {
            ErrorMessage = CultureManager.Get(Resource.LANGUAGE_WAS_NOT_SETTED);
        }
    }
}
