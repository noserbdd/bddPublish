using System.Configuration;

namespace Driver_AutoTests
{
    public static class ApplicationSettings
    {
        public static string HomePath => ConfigurationManager.AppSettings["HomePath"];
    }
}
