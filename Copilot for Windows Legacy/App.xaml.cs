using CefSharp;
using CefSharp.Wpf;
using System;
using System.IO;
using System.Windows;
using System.Threading;

namespace Copilot_for_Windows_Legacy
{
    public partial class App : Application
    {
        private static Mutex mutex;
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

           // SingleInstance();
        }


        //This still doesn't work
        public void SingleInstance()
        {
            const string appName = "Copilot for Windows Legacy";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                MessageBox.Show("The application is already running.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    

        //Shutdown CEF
        protected override void OnExit(ExitEventArgs e)
        {
            Cef.Shutdown();
            base.OnExit(e);
        }
    }
}