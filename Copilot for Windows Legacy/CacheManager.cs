using CefSharp.Wpf;
using CefSharp;

namespace Copilot_for_Windows_Legacy
{
    class CacheManager
    {
        public static void ConfigureCache()
        {
            var settings = new CefSettings();
            settings.CachePath = @"C:\MeuApp\Cache";
            settings.BrowserSubprocessPath = "CefSharp.BrowserSubprocess.exe";
            Cef.Initialize(settings);
            Log();


            if (!Cef.IsInitialized)
            {
                Cef.Initialize(settings);
            }
        }

        public static void Log()
        {
            var settings = new CefSettings();
            settings.LogSeverity = LogSeverity.Info;
            settings.LogFile = @"C:\MeuApp\cef_log.txt";

        }
    }
}
