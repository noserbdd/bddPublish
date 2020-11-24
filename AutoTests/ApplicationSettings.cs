using System.Configuration;

namespace Driver_AutoTests
{
    public static class ApplicationSettings
    {
        public static string TestsVideoDirectory => ConfigurationManager.AppSettings["TestsVideoDirectory"];
        public static string FfmpegFilePath => ConfigurationManager.AppSettings["FfmpegFilePath"];
        public static string HomePath => ConfigurationManager.AppSettings["HomePath"];
    }
}
