using System.ComponentModel;

namespace Dort.Enum
{
    public enum Integration
    {
        [Description("google book")]
        GOOGLE_BOOK = 0
    }

    public enum IntegrationUrl
    {
        [Description("https://www.googleapis.com/")]
        GOOGLE_BOOK = 0
    }

    public enum BookStatus
    {
        READING = 0,
        READ = 1,
        WANT_TO_READ = 2
    }

    public enum Resource
    {
        ENUM_WITHOUT_DESCRIPTION = 0,
        RESOURCE_WITHOUT_DESCRIPTION = 1,
        LANGUAGE_WAS_NOT_SETTED = 2,
    }
}
