using CefSharp;
using CefSharp.Wpf;
using System;
using System.IO;
using System.Windows;

namespace Copilot_for_Windows_Legacy
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        { 
            var settings = new CefSettings();

            // Cache location
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cachePath = Path.Combine(appDataPath, "CopilotFWL", "Cache");

            // Maker dir
            if (!Directory.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }

            settings.CachePath = cachePath;
            settings.LogSeverity = LogSeverity.Verbose;

            // Inicialize CEF
            if (!Cef.IsInitialized)
            {
                Cef.Initialize(settings);
            }
            base.OnStartup(e);
        }

        //Shutdown CEF
        protected override void OnExit(ExitEventArgs e)
        {
            Cef.Shutdown();
            base.OnExit(e);
        }
    }
}